using System.ComponentModel.DataAnnotations;

namespace WarehouseManagementApp.Models
{
    public class Permission
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(100)]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public ICollection<RolePermission> RolePermissions { get; set; }
    }
}
