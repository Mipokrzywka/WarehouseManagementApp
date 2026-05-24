using System.ComponentModel.DataAnnotations;

namespace WarehouseManagementApp.Models
{
    public class TaskStatus
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        public ICollection<WorkTask> Tasks { get; set; } = new List<WorkTask>();
    }
}
