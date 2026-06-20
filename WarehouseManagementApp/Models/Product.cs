using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WarehouseManagementApp.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public ProductCategory? Category { get; set; }
        public int? BrandId { get; set; }
        [ForeignKey("BrandId")]
        public Brand? Brand { get; set; }
        [Required]
        public string QrCode { get; set; } = string.Empty;
        [Required]
        public string Name {  get; set; } = string.Empty;
        [Range(0, int.MaxValue, ErrorMessage = "Quantity cannot be negative")]
        public int Quantity { get; set; }
        [Column(TypeName = "decimal(10, 2)"), Range(0.01, (double)decimal.MaxValue, ErrorMessage = "Cost has to be higher than 0")]
        public decimal CostAmt {  get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? ForecastDepletionDate {  get; set; }
        public DateTime? ForecastUpdatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public ICollection<ProductChange> ProductChanges { get; set; } = new List<ProductChange>();
        public ICollection<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();
    }
}
