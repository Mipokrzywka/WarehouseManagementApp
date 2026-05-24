using System.ComponentModel.DataAnnotations;

namespace WarehouseManagementApp.Models
{
    public class ProductCategory
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(255)]
        public string Name { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
