using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WarehouseManagementApp.Models;
using WarehouseManagementApp.Data;
using System.Text.Json;
using WarehouseManagementApp.Interfaces;
using WarehouseManagementApp.Mappers;
using WarehouseManagementApp.DTOs;
using WarehouseManagementApp.Enums;
using WarehouseManagementApp.Controllers;
using Microsoft.AspNetCore.Authorization;
using WarehouseManagementApp.Security;

[Route("api/[controller]")]
[ApiController]
public class ProductCategoriesController : BaseApiController
{
    private readonly IProductCategoryRepository _productCategoryRepository;
    private readonly IActivityLogRepository _activityLogRepository;
    public ProductCategoriesController(IProductCategoryRepository productCategoryRepository, IActivityLogRepository activityLogRepository)
    {
        _productCategoryRepository = productCategoryRepository;
        _activityLogRepository = activityLogRepository;
    }

    [HttpGet]
    [Authorize(Policy = AppPermissions.ProductCategoriesRead)]
    [ProducesResponseType (200, Type = typeof(IEnumerable<ProductCategoryReadDto>))]
    public IActionResult GetProductCategories()
    {
        var productCategories = _productCategoryRepository.GetCategoriesWithProducts();

        var productCategoriesDto = productCategories.Select(pc => pc.ToReadDto());
        return Ok(productCategoriesDto);
    }

    [HttpGet("{productCategoryId:int}")]
    [Authorize(Policy = AppPermissions.ProductCategoriesRead)]
    [ProducesResponseType(200, Type = typeof(ProductCategoryReadDto))]
    [ProducesResponseType(404)]
    public IActionResult GetProductCategoryById(int productCategoryId)
    {
        var productCategory = _productCategoryRepository.GetById(productCategoryId);

        if (productCategory == null)
        {
            return NotFound($"Product category with id {productCategoryId} does not exist");
        }

        return Ok(productCategory.ToReadDto());
    }

    [HttpPut("{productCategoryId:int}")]
    [Authorize(Policy = AppPermissions.ProductCategoriesManage)]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public IActionResult UpdateProductCategory(int productCategoryId, [FromBody] ProductCategoryUpdateDto productCategoryDto)
    {
        if (productCategoryDto == null)
            return BadRequest("Invalid product category data");
        var existingProductCategory = _productCategoryRepository.GetById(productCategoryId);
        if (existingProductCategory == null)
            return NotFound($"Product category with id {productCategoryId} does not exist");        
        if (_productCategoryRepository.NameExists(productCategoryDto.Name, existingProductCategory.Id))
            return BadRequest($"Product category with name {productCategoryDto.Name} already exists");
        var originalData = JsonSerializer.Serialize(existingProductCategory.ToReadDto());
        ProductCategoryMapper.UpdateFromDto(existingProductCategory, productCategoryDto);
        if (!_productCategoryRepository.Update(existingProductCategory))
            return StatusCode(500, "Failed to update product category");
        ActivityLog log = new ActivityLog()
        {
            ModuleId = (int)ModuleEnum.ProductCategories,
            ComponentId = existingProductCategory.Id,
            Action = "Update",
            UserId = CurrentUserID,
            CreatedAt = DateTime.UtcNow,
            OldData = originalData,
            NewData = JsonSerializer.Serialize(existingProductCategory.ToReadDto())
        };
        _activityLogRepository.Create(log);
        return NoContent();
    }


    [HttpPost]
    [Authorize(Policy = AppPermissions.ProductCategoriesManage)]
    [ProducesResponseType(201, Type = typeof(ProductCategoryReadDto))]
    [ProducesResponseType(400)]
    public IActionResult CreateProductCategory([FromBody] ProductCategoryCreateDto productCategoryDto)
    {
        if (productCategoryDto == null)
            return BadRequest("Product category cannot be null");
        if (_productCategoryRepository.NameExists(productCategoryDto.Name))
            return BadRequest($"Product category with name {productCategoryDto.Name} already exists");
        var createdProductCategory = ProductCategoryMapper.CreateDtoToProduct(productCategoryDto);
        if (!_productCategoryRepository.Create(createdProductCategory))
            return StatusCode(500, "Failed to create product category");
        ActivityLog log = new ActivityLog
        {
            ModuleId = (int)ModuleEnum.ProductCategories,
            ComponentId = createdProductCategory.Id,
            Action = "Create",
            UserId = CurrentUserID,
            CreatedAt = DateTime.UtcNow,
            NewData = JsonSerializer.Serialize(createdProductCategory.ToReadDto())
        };
        _activityLogRepository.Create(log);
        return CreatedAtAction(nameof(GetProductCategoryById), new { productCategoryId = createdProductCategory.Id }, createdProductCategory.ToReadDto());
    }

    [HttpDelete("{productCategoryId:int}")]
    [Authorize(Policy = AppPermissions.ProductCategoriesManage)]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public IActionResult DeleteProductCategory(int productCategoryId)
    {
        var existingProductCategory = _productCategoryRepository.GetById(productCategoryId);
        if (existingProductCategory == null)
            return NotFound($"Product category with id {productCategoryId} does not exist");
        if (_productCategoryRepository.HasProducts(productCategoryId))
        {
            return BadRequest("Cannot delete a category that contains products. Reassign the products first.");
        }
        var oldData = JsonSerializer.Serialize(existingProductCategory.ToReadDto());
        
        if (!_productCategoryRepository.SoftDelete(existingProductCategory))
            return StatusCode(500, "Failed to delete product category");
        ActivityLog log = new ActivityLog()
        {
            ModuleId = (int)ModuleEnum.ProductCategories,
            ComponentId = existingProductCategory.Id,
            Action = "Delete",
            UserId = CurrentUserID,
            CreatedAt = DateTime.UtcNow,
            OldData = oldData,
            NewData = ""
        };
        _activityLogRepository.Create(log);
        return NoContent();
    }
}
