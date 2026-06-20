using System.ComponentModel.DataAnnotations;

namespace WarehouseManagementApp.DTOs
{
    public class OrderReadDto
    {
        public int Id { get; set; }
        public int StatusId { get; set; }
        public string StatusName { get; set; } = string.Empty;
        public int CreatorId { get; set; }
        public string CreatorEmail { get; set; } = string.Empty;
        public int? ReviewerId { get; set; }
        public string? ReviewerEmail { get; set; }
        public decimal CostAmt { get; set; }
        public ICollection<OrderProductReadDto> OrderProducts { get; set; } = new List<OrderProductReadDto>();
    }
    public class OrderProductReadDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public int BrandId { get; set; }
        public string BrandName { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal CostAmt { get; set; }
    }
    public class OrderUpdateDto
    {
        [Required]
        public ICollection<OrderProductCreateDto> OrderProducts { get; set; } = new List<OrderProductCreateDto>();
    }
    public class OrderProductCreateDto
    {
        [Required]
        public int ProductId { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1")]
        public int Quantity { get; set; }
    }
    public class OrderCreateDto
    {
        [Required]
        public ICollection<OrderProductCreateDto> OrderProducts { get; set; } = new List<OrderProductCreateDto>();
    }
}
