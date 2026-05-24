using System.ComponentModel.DataAnnotations;

namespace WarehouseManagementApp.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(100)]
        public string Email { get; set; } = string.Empty;
        [Required, StringLength(100)]
        public string FirstName { get; set; } = string.Empty;
        [Required, StringLength(100)]
        public string Surname { get; set; } = string.Empty;
        [Required, StringLength(255)]
        public string PasswordHash { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? DeletedAt { get; set;}
        public DateTime? UpdatedAt { get; set; }
        public ICollection<UserNotification> UserNotifications { get; set; } = new List<UserNotification>();
        public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
        public ICollection<Order> UserOrders { get; set; } = new List<Order>();
        public ICollection<ProductChange> UserProductChanges { get; set; } = new List<ProductChange>();

    }
}
