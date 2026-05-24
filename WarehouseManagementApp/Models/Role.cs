using System.ComponentModel.DataAnnotations;

namespace WarehouseManagementApp.Models
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(100)]
        public string Name { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt {  get; set; }
        public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
        public ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();
    }
}
