using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WarehouseManagementApp.Models;
using WarehouseManagementApp.Data;
using WarehouseManagementApp.Interfaces;
using WarehouseManagementApp.Mappers;
using WarehouseManagementApp.DTOs;


namespace WarehouseManagementApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Product>))]

        public IActionResult GetProducts()
        {
            var products = _productRepository.GetAll();

            var productsDto = products.Select(p => p.ToReadDto());
            return Ok(productsDto);
        }

        [HttpGet("{productId:int}")]
        [ProducesResponseType(200, Type = typeof(Product))]
        [ProducesResponseType(404)]
        public IActionResult GetProductById(int productId)
        {      
            var product = _productRepository.GetById(productId);
            if(product == null)
                return NotFound($"Product with id {productId} does not exist.");
            return Ok(product.ToReadDto());
        }
        [HttpGet("qr/{qrCode}")]
        [ProducesResponseType(200, Type = typeof(Product))]
        [ProducesResponseType(404)]
        public IActionResult GetProductByQrCode(string qrCode)
        {
            var product = _productRepository.GetByQrCode(qrCode);
            if (product == null)
                return NotFound($"Product with QR code {qrCode} does not exist.");
            return Ok(product.ToReadDto());
        }
        [HttpGet("category/{categoryId:int}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Product>))]
        public IActionResult GetProductsByCategoryId(int categoryId)
        {
            var products = _productRepository.GetByCategory(categoryId);
            var productsDto = products.Select(p => p.ToReadDto());
            return Ok(productsDto);
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(Product))]
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
            return CreatedAtAction(nameof(GetProductById), new { productId = createdProduct.Id }, createdProduct.ToReadDto());
        }
        [HttpPut("{productId:int}")]
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
            ProductMapper.UpdateFromDto(existingProduct, productDto);
            if (!_productRepository.Update(existingProduct))
                return StatusCode(500, "Failed to update product.");
            return NoContent();
        }
        [HttpDelete("{productId:int}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]

        public IActionResult DeleteProduct(int productId)
        {
            if (!_productRepository.Exists(productId))
                return NotFound($"Product with id {productId} does not exist.");
            if (!_productRepository.SoftDelete(productId))
                return StatusCode(500, "Failed to delete product.");
            return NoContent();
        }
    }
}

