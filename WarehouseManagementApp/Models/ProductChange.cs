using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WarehouseManagementApp.Models
{
    public class ProductChange
    {
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product? Product { get; set; }
        [Required]
        public string Reason { get; set; } = string.Empty;
        public int QuantityChanged { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public int CreatedById { get; set; }
        [ForeignKey("CreatedById")]
        public User? CreatedBy { get; set; }
    }
}
