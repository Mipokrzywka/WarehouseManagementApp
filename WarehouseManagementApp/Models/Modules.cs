using System.ComponentModel.DataAnnotations;

namespace WarehouseManagementApp.Models
{
    public class Module
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(100)]
        public string Name { get; set; } = string.Empty;
        public ICollection<ActivityLog> ActivityLogs { get; set; } = new List<ActivityLog>();
    }
}
