using System.ComponentModel.DataAnnotations;

namespace WarehouseManagementApp.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(100)]
        public string Email { get; set; }
        [Required, StringLength(100)]
        public string FirstName { get; set; }
        [Required, StringLength(100)]
        public string Surname { get; set; }
        [Required, StringLength(255)]
        public string PasswordHash { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? DeletedAt { get; set;}
        public DateTime? UpdatedAt { get; set; }
        public ICollection<UserNotification>? UserNotifications { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
        public ICollection<Order> UserOrders { get; set; }
        public ICollection<ProductChange> UserProductChanges {  get; set; }

    }
}
