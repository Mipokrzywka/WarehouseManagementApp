using WarehouseManagementApp.DTOs;
using WarehouseManagementApp.Models;

namespace WarehouseManagementApp.Mappers
{
    public static class OrderProductMapper
    {
        public static OrderProductReadDto ToReadDto(this OrderProduct orderProduct)
        {
            return new OrderProductReadDto
            {
                ProductId = orderProduct.ProductId,
                ProductName = orderProduct.Product?.Name ?? "",
                CategoryId = orderProduct.Product?.CategoryId ?? 0,
                CategoryName = orderProduct.Product?.Category?.Name ?? "",
                Quantity = orderProduct.Quantity,
                CostAmt = orderProduct?.CostAmt ?? 0
            };
        }

        public static OrderProduct CreateDtoToOrderProduct(this OrderProductCreateDto dto)
        {
            return new OrderProduct
            {
                ProductId = dto.ProductId,
                Quantity = dto.Quantity
            };
        }
    }
}
