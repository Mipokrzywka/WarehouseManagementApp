using System.ComponentModel.DataAnnotations.Schema;

namespace WarehouseManagementApp.Models
{
    public class UserRole
    {
        public int RoleId { get; set; }
        [ForeignKey("RoleId")]
        public Role? Role { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User? User { get; set; }

    }
}
