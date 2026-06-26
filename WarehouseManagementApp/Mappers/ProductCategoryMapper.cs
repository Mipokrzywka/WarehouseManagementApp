using WarehouseManagementApp.DTOs;
using WarehouseManagementApp.Models;

namespace WarehouseManagementApp.Mappers
{
    public static class ProductCategoryMapper
    {
        public static ProductCategoryReadDto ToReadDto(this ProductCategory productCategory)
        {
            return new ProductCategoryReadDto()
            {
                Id = productCategory.Id,
                Name = productCategory.Name,
                ProductCount = productCategory.
                                Products.
                                Count()
            };
        }

        public static ProductCategory CreateDtoToProduct(ProductCategoryCreateDto dto)
        {
            DateTime createdAt = DateTime.UtcNow;
            return new ProductCategory()
            {
                Name = dto.Name,
                CreatedAt = createdAt,
                UpdatedAt = createdAt
            };
        }

        public static void UpdateFromDto(ProductCategory productCategory, ProductCategoryUpdateDto dto)
        {
            productCategory.Name = dto.Name;
            productCategory.UpdatedAt = DateTime.UtcNow;
        }
    }
}
