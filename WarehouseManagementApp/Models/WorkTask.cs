using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WarehouseManagementApp.Models
{
    public class WorkTask
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Description { get; set; } = string.Empty;
        public int StatusId {  get; set; }
        [ForeignKey("StatusId")]
        public TaskStatus Status { get; set; }
        public int RoleId {  get; set; }
        [ForeignKey("RoleId")]
        public Role Role { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set;}
        public DateTime? DeletedAt { get; set;}
    }
}
