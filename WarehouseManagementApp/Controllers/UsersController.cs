using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Xml;
using WarehouseManagementApp.Controllers;
using WarehouseManagementApp.Data;
using WarehouseManagementApp.DTOs;
using WarehouseManagementApp.Enums;
using WarehouseManagementApp.Interfaces;
using WarehouseManagementApp.Mappers;
using WarehouseManagementApp.Models;
using WarehouseManagementApp.Repository;
using WarehouseManagementApp.Security;
using System.Security;

[Route("api/[controller]")]
[ApiController]
public class UsersController : BaseApiController
{
    private readonly IRoleRepository _roleRepository;
    private readonly IUserRepository _userRepository;
    private readonly IActivityLogRepository _activityLogRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly ITokenService _tokenService;

    public UsersController(
        IRoleRepository roleRepository,
        IUserRepository userRepository,
        IActivityLogRepository activityLogRepository,
        IPasswordHasher passwordHasher,
        ITokenService tokenService)
    {
        _roleRepository = roleRepository;
        _userRepository = userRepository;
        _activityLogRepository = activityLogRepository;
        _passwordHasher = passwordHasher;
        _tokenService = tokenService;
    }

    [HttpGet]
    [Authorize(Policy = AppPermissions.UsersRead)]
    [ProducesResponseType(200, Type = typeof(IEnumerable<UserReadDto>))]
    public IActionResult GetUsers()
    {
        var users = _userRepository.GetAllUsersWithRoles();
        var usersDto = users.Select(u => u.ToReadDto()).ToList();
        return Ok(usersDto);
    }

    [HttpGet("{id:int}")]
    [Authorize(Policy = AppPermissions.UsersRead)]
    [ProducesResponseType(200, Type = typeof(UserReadDto))]
    [ProducesResponseType(404)]
    public IActionResult GetUserById(int id)
    {
        var user = _userRepository.GetUserWithRolesAndPermissions(id);
        if (user == null)
            return NotFound($"User with id {id} does not exist");
        return Ok(user.ToReadDto());
    }

    [HttpPut("{id:int}")]
    [Authorize(Policy = AppPermissions.UsersManage)]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public IActionResult UpdateUser(int id, [FromBody] UserUpdateDto dto)
    {
        if (dto == null)
            return BadRequest("Incorrect user data");
        var user = _userRepository.GetUserWithRolesAndPermissions(id);
        if (user == null)
            return BadRequest($"User with id {id} does not exist");
        if (dto.RoleIds == null || !dto.RoleIds.Any())
            return BadRequest("User must have at least one role");

        var existingRoles = _roleRepository.GetAll().Select(r => r.Id).ToList();
        var invalidRoles = dto.RoleIds.Except(existingRoles).ToList();

        if (invalidRoles.Any())
            return BadRequest($"Roles with ids {string.Join(", ", invalidRoles)} do not exist");
        var oldData = System.Text.Json.JsonSerializer.Serialize(user.ToReadDto());
        user.FirstName = dto.FirstName;
        user.Surname = dto.Surname;
        user.UpdatedAt = DateTime.UtcNow;
        user.UserRoles = dto.RoleIds.Select(rId => new UserRole
        {
            RoleId = rId,
        }).ToList();

        if (!_userRepository.Update(user))
            return BadRequest("Failed to update user");

        var newData = System.Text.Json.JsonSerializer.Serialize(user.ToReadDto());
        ActivityLog log = new ActivityLog()
        {
            ModuleId = (int)ModuleEnum.Users,
            ComponentId = user.Id,
            Action = "Update",
            UserId = CurrentUserID,
            CreatedAt = DateTime.UtcNow,
            OldData = oldData,
            NewData = newData
        };

        _activityLogRepository.Create(log);

        return NoContent();
    }

    [HttpPost("Login")]
    [AllowAnonymous]
    [ProducesResponseType(200)]
    [ProducesResponseType(401)]
    public IActionResult Login([FromBody] UserLoginDto dto)
    {
        var user = _userRepository.GetUserWithRolesAndPermissions(email: dto.Email);
        if (user == null || !_passwordHasher.VerifyPassword(dto.Password, user.PasswordHash))
            return Unauthorized("Wrong email or password");

        var token = _tokenService.GenerateToken(user);

        var userDto = user.ToReadDto();
        ActivityLog log = new ActivityLog()
        {
            ModuleId = (int)ModuleEnum.Users,
            ComponentId = user.Id,
            Action = "Login",
            UserId = user.Id, 
            CreatedAt = DateTime.UtcNow,
            OldData = "",
            NewData = ""
        };
        _activityLogRepository.Create(log);
        return Ok(new
        {
            Token = token,
            User = userDto
        });
    }


    [HttpPut("ChangePassword")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public IActionResult ChangePassword([FromBody] UserPasswordUpdateDto dto)
    {
        int id = CurrentUserID;
        var user = _userRepository.GetUserWithRolesAndPermissions(id);
        if (user == null)
            return NotFound($"User with id {id} does not exist");
        if (!_passwordHasher.VerifyPassword(dto.CurrentPassword, user.PasswordHash))
            return BadRequest("Current password is incorrect");
        user.PasswordHash = _passwordHasher.HashPassword(dto.NewPassword);
        user.UpdatedAt = DateTime.UtcNow;
        if (!_userRepository.Update(user))
            return BadRequest("Failed to update password");
        ActivityLog log = new ActivityLog()
        {
            ModuleId = (int)ModuleEnum.Users,
            ComponentId = user.Id,
            Action = "Password change",
            UserId = CurrentUserID,
            CreatedAt = DateTime.UtcNow,
            OldData = "",
            NewData = ""
        };
        _activityLogRepository.Create(log);
        return NoContent();
    }


    [HttpPost]
    [Authorize(Policy = AppPermissions.UsersManage)]
    [ProducesResponseType(201, Type = typeof(UserReadDto))]
    [ProducesResponseType(400)]
    public IActionResult CreateUser([FromBody] UserCreateDto dto)
    {
        if (dto == null)
            return BadRequest("Invalid user data");
        if (dto.RoleIds == null || !dto.RoleIds.Any())
            return BadRequest("User must have at least one role");
        if (_userRepository.EmailExists(dto.Email))
            return BadRequest($"User with email {dto.Email} already exists");

        var existingRoles = _roleRepository.GetAll().Select(r => r.Id).ToList();
        var invalidRoles = dto.RoleIds.Except(existingRoles).ToList();
        if (invalidRoles.Any())
            return BadRequest($"Roles with ids {string.Join(", ", invalidRoles)} do not exist");

        //string password = Path.GetRandomFileName().Replace(".", "");
        string password = "Password";

        string hashedPassword = _passwordHasher.HashPassword(password);

        var createdUser = new User()
        {
            Email = dto.Email,
            FirstName = dto.FirstName,
            Surname = dto.Surname,
            PasswordHash = hashedPassword,
            CreatedAt = DateTime.UtcNow,
            UserRoles = dto.RoleIds.Select(rId => new UserRole
            {
                RoleId = rId,
            }).ToList()
        };

            if (!_userRepository.Create(createdUser))
                return BadRequest("Failed to create user");

        var fetchedUser = _userRepository.GetUserWithRolesAndPermissions(createdUser.Id);
        if (fetchedUser == null)
            return BadRequest("User created, but failed to fetch data");
        var userReadDto = fetchedUser.ToReadDto();
        var newData = System.Text.Json.JsonSerializer.Serialize(userReadDto);

        ActivityLog log = new ActivityLog()
        {
            ModuleId = (int)ModuleEnum.Users,
            ComponentId = createdUser.Id,
            Action = "Create",
            UserId = CurrentUserID,
            CreatedAt = DateTime.UtcNow,
            OldData = "",
            NewData = newData
        };
        _activityLogRepository.Create(log);
        return CreatedAtAction(nameof(GetUserById), new { id = createdUser.Id }, userReadDto);
    }

    [HttpDelete("{id:int}")]
    [Authorize(Policy = AppPermissions.UsersManage)]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public IActionResult DeleteUser(int id)
    {
        var user = _userRepository.GetUserWithRolesAndPermissions(id);
        if (user == null)
            return NotFound($"User with id {id} does not exist");
        var oldData = System.Text.Json.JsonSerializer.Serialize(user.ToReadDto());
        if (!_userRepository.SoftDelete(user))
            return BadRequest("Failed to delete user");
        ActivityLog log = new ActivityLog()
        {
            ModuleId = (int)ModuleEnum.Users,
            ComponentId = user.Id,
            Action = "Delete",
            UserId = CurrentUserID,
            CreatedAt = DateTime.UtcNow,
            OldData = oldData,
            NewData = ""
        };
        _activityLogRepository.Create(log);
        return NoContent();
    }
}
