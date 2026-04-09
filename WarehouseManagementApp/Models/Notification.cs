using System.ComponentModel.DataAnnotations;

namespace WarehouseManagementApp.Models
{
    public class Notification
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public ICollection<UserNotification> UserNotifications { get; set; }
    }
}
