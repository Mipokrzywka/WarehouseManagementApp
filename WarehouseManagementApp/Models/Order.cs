using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WarehouseManagementApp.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public int StatusId { get; set; }
        [ForeignKey("StatusId")]
        public OrderStatus? Status { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt {  get; set; }
        public DateTime? DeletedAt { get; set; }
        public int CreatorId { get; set; }
        [ForeignKey("CreatorId")]
        public User? CreatedBy { get; set; }
        public int? ReviewerId {  get; set; }
        [ForeignKey("ReviewerId")]
        public User? Reviewer { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal CostAmt {  get; set; }
        public ICollection<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();
    }
}
