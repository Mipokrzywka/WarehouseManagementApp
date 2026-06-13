using WarehouseManagementApp.DTOs;
using WarehouseManagementApp.Models;

namespace WarehouseManagementApp.Mappers
{
    public static class OrderMapper
    {
        public static OrderReadDto ToReadDto(this Order order)
        {
            return new OrderReadDto
            {
                Id = order.Id,
                StatusId = order.StatusId,
                StatusName = order.Status?.Name ?? "",
                CreatorId = order.CreatorId,
                CreatorEmail = order.CreatedBy?.Email ?? "",
                ReviewerId = order.ReviewerId,
                ReviewerEmail = order.Reviewer?.Email,
                CostAmt = order.CostAmt,
                OrderProducts = order.OrderProducts != null ?
                    order.OrderProducts.Select(op => op.ToReadDto()).ToList()
                    : new List<OrderProductReadDto>()
            };
        }
        public static Order CreateDtoToOrder(OrderCreateDto dto)
        {
            return new Order
            {
                StatusId = (int)OrderStatusEnum.New,
                CreatorId = dto.CreatorId,
                OrderProducts = dto.OrderProducts != null ?
                    dto.OrderProducts.Select(op => op.CreateDtoToOrderProduct()).ToList()
                    : new List<OrderProduct>()
            };
        }
    }
}
