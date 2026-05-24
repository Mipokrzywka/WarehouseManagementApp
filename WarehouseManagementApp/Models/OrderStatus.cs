using System.ComponentModel.DataAnnotations;

namespace WarehouseManagementApp.Models
{
    public class OrderStatus
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(100)]
        public string Name { get; set; } = string.Empty;
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
