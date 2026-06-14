using System.ComponentModel.DataAnnotations;
using WarehouseManagementApp.Models;

namespace WarehouseManagementApp.DTOs
{
    public class RoleReadDto
    {
        public int RoleId { get; set; }
        public string Name { get; set; } = string.Empty;
        public IEnumerable<PermissionReadDto> Permissions { get; set; } = new List<PermissionReadDto>();
        public IEnumerable<string> Emails { get; set; } = new List<string>();
    }
    public class RoleUpdateDto
    {
       [Required]
       public string Name { get; set; } = string.Empty;
        [Required]
       public IEnumerable<int> PermissionIds{ get; set; } = new List<int>();
    }
    public class RoleCreateDto 
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public IEnumerable<int> PermissionIds { get; set; } = new List<int>();
    }
}
