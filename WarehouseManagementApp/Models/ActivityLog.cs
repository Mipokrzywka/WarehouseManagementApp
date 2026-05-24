using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WarehouseManagementApp.Models
{
    public class ActivityLog
    {
        [Key]     
        public int Id { get; set; }
        public int ModuleId { get; set; }
        [ForeignKey("ModuleId")]
        public Module? Module { get; set; }
        public int ComponentId { get; set; }
        [StringLength(100), Required]
        public string Action { get; set; } = string.Empty;
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User? User { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string OldData { get; set; } = string.Empty;
        [Required]
        public string NewData { get; set;} = string.Empty;
    }
}
