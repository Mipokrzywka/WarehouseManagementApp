using System.ComponentModel.DataAnnotations;

namespace WarehouseManagementApp.DTOs
{
    public class UserReadDto
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;

        public IEnumerable<string> Roles { get; set;} = new List<string>();
        public IEnumerable<string> Permissions { get; set; } = new List<string>();
    }
    public class UserCreateDto 
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "Password is required")]
        [MinLength(6, ErrorMessage = "Password length has to be at least 6 characters")]
        public string Password {  get; set; } = string.Empty;
        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Surname is required")]
        public string Surname { get; set;} = string.Empty;
        [Required(ErrorMessage = "User has to have at least 1 role")]
        public IEnumerable <int> RoleIds { get; set;} = new List<int>();
    }
    public class UserUpdateDto 
    {
        public string FirstName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Surname is required")]
        public string Surname { get; set; } = string.Empty;
        [Required(ErrorMessage = "User has to have at least 1 role")]
        public IEnumerable<int> RoleIds { get; set; } = new List<int>();
    }

    public class UserLoginDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
    }
    public class UserPasswordUpdateDto
    {
        [Required(ErrorMessage = "Current password is required")]
        public string CurrentPassword {  get; set; } = string.Empty;
        [Required(ErrorMessage = "New password is required")]
        [MinLength(6, ErrorMessage = "Password length has to be at least 6 characters")]
        public string NewPassword {  get; set; } = string.Empty;
    }
}
