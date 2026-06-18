using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WarehouseManagementApp.Models;
using WarehouseManagementApp.Data;
using System.Text.Json;
using WarehouseManagementApp.Interfaces;
using WarehouseManagementApp.Mappers;
using WarehouseManagementApp.DTOs;
using WarehouseManagementApp.Enums;
using Microsoft.AspNetCore.Authorization;
using WarehouseManagementApp.Security;


namespace WarehouseManagementApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : BaseApiController
    {
        private readonly IProductRepository _productRepository;
        private readonly IActivityLogRepository _activityLogRepository;
        public ProductsController(IProductRepository productRepository, IActivityLogRepository activityLogRepository)
        {
            _productRepository = productRepository;
            _activityLogRepository = activityLogRepository;
        }

        [HttpGet]
        [Authorize(Policy = AppPermissions.ProductsRead)]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ProductReadDto>))]

        public IActionResult GetProducts()
        {
            var products = _productRepository.GetAll();

            var productsDto = products.Select(p => p.ToReadDto());
            return Ok(productsDto);
        }

        [HttpGet("{productId:int}")]
        [Authorize(Policy = AppPermissions.ProductsRead)]
        [ProducesResponseType(200, Type = typeof(ProductReadDto))]
        [ProducesResponseType(404)]
        public IActionResult GetProductById(int productId)
        {      
            var product = _productRepository.GetById(productId);
            if(product == null)
                return NotFound($"Product with id {productId} does not exist.");
            return Ok(product.ToReadDto());
        }
        [HttpGet("qr/{qrCode}")]
        [Authorize(Policy = AppPermissions.ProductsRead)]
        [ProducesResponseType(200, Type = typeof(ProductReadDto))]
        [ProducesResponseType(404)]
        public IActionResult GetProductByQrCode(string qrCode)
        {
            var product = _productRepository.GetByQrCode(qrCode);
            if (product == null)
                return NotFound($"Product with QR code {qrCode} does not exist.");
            return Ok(product.ToReadDto());
        }
        [HttpGet("category/{categoryId:int}")]
        [Authorize(Policy = AppPermissions.ProductsRead)]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ProductReadDto>))]
        public IActionResult GetProductsByCategoryId(int categoryId)
        {
            var products = _productRepository.GetByCategory(categoryId);
            var productsDto = products.Select(p => p.ToReadDto());
            return Ok(productsDto);
        }

        [HttpPost]
        [Authorize(Policy = AppPermissions.ProductsManage)]
        [ProducesResponseType(201, Type = typeof(ProductReadDto))]
        [ProducesResponseType(400)]
        public IActionResult CreateProduct([FromBody] ProductCreateDto productDto)
        {
            if (productDto == null)
                return BadRequest("Product cannot be null.");            
            if (_productRepository.NameCategoryExists(productDto.Name, productDto.CategoryId))
                return BadRequest($"Product with name {productDto.Name} already exists in category {productDto.CategoryId}.");
            var createdProduct = ProductMapper.CreateDtoToProduct(productDto);
            if (!_productRepository.Create(createdProduct))
                return StatusCode(500, "Failed to create product.");
            ActivityLog log = new ActivityLog()
            {
                ModuleId = (int)ModuleEnum.Products,
                ComponentId = createdProduct.Id,
                Action = "Create",
                UserId = CurrentUserID,
                CreatedAt = DateTime.UtcNow,
                NewData = JsonSerializer.Serialize(createdProduct.ToReadDto())
            };
            _activityLogRepository.LogActivity(log);
            return CreatedAtAction(nameof(GetProductById), new { productId = createdProduct.Id }, createdProduct.ToReadDto());
        }
        [HttpPut("{productId:int}")]
        [Authorize(Policy = AppPermissions.ProductsManage)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]

        public IActionResult UpdateProduct(int productId, [FromBody] ProductUpdateDto productDto)
        {
            if (productDto == null)
                return BadRequest("Invalid product data.");
            var existingProduct = _productRepository.GetById(productId);
            if (existingProduct == null)
                return NotFound($"Product with id {productId} does not exist.");
            if (_productRepository.NameCategoryExists(productDto.Name, productDto.CategoryId, productId))
                return BadRequest($"Another product with name {productDto.Name} already exists in category {productDto.CategoryId}.");
            var oldProductData = JsonSerializer.Serialize(existingProduct.ToReadDto());
            ProductMapper.UpdateFromDto(existingProduct, productDto);
            if (!_productRepository.Update(existingProduct))
                return StatusCode(500, "Failed to update product.");
            ActivityLog log = new ActivityLog()
            {
                ModuleId = (int)ModuleEnum.Products,
                ComponentId = existingProduct.Id,
                Action = "Update",
                UserId = CurrentUserID,
                CreatedAt = DateTime.UtcNow,
                OldData = oldProductData,
                NewData = JsonSerializer.Serialize(existingProduct.ToReadDto())
            };
            _activityLogRepository.LogActivity(log);
            return NoContent();
        }
        [HttpDelete("{productId:int}")]
        [Authorize(Policy = AppPermissions.ProductsManage)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]

        public IActionResult DeleteProduct(int productId)
        {
            var product = _productRepository.GetById(productId);
            if (product == null)
                return NotFound($"Product with id {productId} does not exist.");
            var oldProductData = JsonSerializer.Serialize(product.ToReadDto());
            if (!_productRepository.SoftDelete(product))
                return StatusCode(500, "Failed to delete product.");
            ActivityLog log = new ActivityLog()
            {
                ModuleId = (int)ModuleEnum.Products,
                ComponentId = productId,
                Action = "Delete",
                UserId = CurrentUserID,
                CreatedAt = DateTime.UtcNow,
                OldData = oldProductData,
                NewData = ""
            };
            _activityLogRepository.LogActivity(log);
            return NoContent();
        }
    }
}

