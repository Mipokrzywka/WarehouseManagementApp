using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WarehouseManagementApp.Models
{
    public class OrderProduct
    {
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product? Product { get; set; }
        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        public Order? Order { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Quantity has to be higher than 0")]
        public int Quantity { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal CostAmt {get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set;}
        public DateTime? DeletedAt { get; set; }
    }
}
