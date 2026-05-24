using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WarehouseManagementApp.Models
{
    public class TaskComment
    {
        [Key]
        public int Id { get; set; }
        public int TaskId {  get; set; }
        [ForeignKey("TaskId")]
        public WorkTask? Task { get; set; }
        [Required]
        public string Content { get; set; } = string.Empty;
        public int CreatedById { get; set; }
        [ForeignKey("CreatedById")]
        public User? CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set;}
        public DateTime? DeletedAt { get; set;}
    }
}
