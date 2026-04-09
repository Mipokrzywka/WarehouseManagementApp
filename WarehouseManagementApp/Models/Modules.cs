using System.ComponentModel.DataAnnotations;

namespace WarehouseManagementApp.Models
{
    public class Module
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(100)]
        public string Name { get; set; }
        public ICollection<ActivityLog> ActivityLogs { get; set; }
    }
}
