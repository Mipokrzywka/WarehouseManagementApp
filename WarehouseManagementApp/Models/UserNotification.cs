using System.ComponentModel.DataAnnotations.Schema;

namespace WarehouseManagementApp.Models
{
    public class UserNotification
    {
        public int UserId { get; set; }
        public int NotificationId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        [ForeignKey("NotificationId")]
        public Notification Notification { get; set; }
    }
}
