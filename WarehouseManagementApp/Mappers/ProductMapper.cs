using Microsoft.EntityFrameworkCore.Query;
using WarehouseManagementApp.DTOs;
using WarehouseManagementApp.Models;
using WarehouseManagementApp.Services;

namespace WarehouseManagementApp.Mappers
{
    public static class ProductMapper
    {
        public static ProductReadDto ToReadDto(this Product product)
        {
            return new ProductReadDto
            {
                Id = product.Id,
                Name = product.Name,
                Quantity = product.Quantity,
                CostAmt = product.CostAmt,
                CategoryId = product.CategoryId,
                CategoryName = product.Category != null ? product.Category.Name : string.Empty,
                BrandId = (int)product.BrandId,
                BrandName = product.Brand != null ? product.Brand.Name : string.Empty,
                ForecastDepletionDate = product.ForecastDepletionDate ?? DateTime.MinValue,
                ForecastUpdatedAt = product.ForecastUpdatedAt ?? DateTime.MinValue,
            };
        }

        public static Product CreateDtoToProduct(ProductCreateDto dto)
        {
            QrCodeService q = new QrCodeService();
            string token = Guid.NewGuid().ToString();
            string qr = q.GenerateQrCode(token);
            DateTime createdAt = DateTime.UtcNow;
            return new Product
            {
                Name = dto.Name,
                Quantity = dto.Quantity,
                CostAmt = dto.CostAmt,
                CategoryId = dto.CategoryId,
                BrandId = dto.BrandId,
                QrCode = qr,
                CreatedAt = createdAt,
                UpdatedAt = createdAt,
                ForecastDepletionDate = createdAt.AddDays(30)
            };
        }

        public static void UpdateFromDto(Product product, ProductUpdateDto dto)
        {
            product.Name = dto.Name;
            product.Quantity = dto.Quantity;
            product.CostAmt = dto.CostAmt;
            product.CategoryId = dto.CategoryId;
            product.BrandId = dto.BrandId;
            product.UpdatedAt = DateTime.UtcNow;
        }

    }
}
