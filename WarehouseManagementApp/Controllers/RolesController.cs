using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security;
using WarehouseManagementApp.Data;
using WarehouseManagementApp.DTOs;
using WarehouseManagementApp.Enums;
using WarehouseManagementApp.Interfaces;
using WarehouseManagementApp.Mappers;
using WarehouseManagementApp.Models;

[Route("api/[controller]")]
[ApiController]
public class RolesController : ControllerBase
{
    private readonly IRoleRepository _roleRepository;
    private readonly IActivityLogRepository _activityLogRepository;
    private readonly ApplicationDbContext _context;
    public RolesController(ApplicationDbContext context,IActivityLogRepository activityLogRepository, IRoleRepository roleRepository)
    {
        _context = context;
        _activityLogRepository = activityLogRepository;
        _roleRepository = roleRepository;
    }

    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<RoleReadDto>))]
    public IActionResult GetRoles()
    {
        var roles = _roleRepository.GetAllRolesWithPermissions();

        var rolesDto = roles.Select(r => r.ToReadDto())
                            .ToList();
        return Ok(rolesDto);
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(200, Type = typeof(RoleReadDto))]
    [ProducesResponseType(404)]
    public IActionResult GetRoleById(int id)
    {
        var role = _roleRepository.GetRoleWithPermissions(id);
        if (role == null)
            return NotFound($"Role with id {id} does not exist");
        return Ok(role.ToReadDto());
    }

    [HttpPut("{id:int}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public IActionResult UpdateRole(int id, [FromBody] RoleUpdateDto dto)
    {
        if (dto == null)
            return BadRequest("Invalid role data");
        if (dto.PermissionIds == null || !dto.PermissionIds.Any())
            return BadRequest("Role has to have at least one permission");

        var existingRole = _roleRepository.GetRoleWithPermissions(id);

        if (existingRole == null)
            return NotFound($"Role with id {id} does not exist");

        if (_roleRepository.GetAll().Any(r => r.Name.ToLower() == dto.Name.ToLower() && r.Id != id))
            return BadRequest($"Role with name {dto.Name} already exists");

        var existingPermissions = _context.Permissions.Select(p => p.Id).ToList();
        var invalidPermissions = dto.PermissionIds.Except(existingPermissions).ToList();
        if (invalidPermissions.Any())
            return BadRequest($"Permissions with ids {string.Join(", ", invalidPermissions)} do not exist");
        var oldData = System.Text.Json.JsonSerializer.Serialize(existingRole.ToReadDto());
        existingRole.Name = dto.Name;
        existingRole.UpdatedAt = DateTime.UtcNow;
        existingRole.RolePermissions.Clear();

        foreach (var permission in dto.PermissionIds)
        {
            existingRole.RolePermissions.Add(new RolePermission()
            {
                RoleId = id,
                PermissionId = permission
            });
        }

        if(!_roleRepository.Update(existingRole))
            return BadRequest("Failed to update role");

        var newData = System.Text.Json.JsonSerializer.Serialize(existingRole.ToReadDto());
        ActivityLog log = new ActivityLog()
        {
            ModuleId = (int)ModuleEnum.Roles,
            ComponentId = existingRole.Id,
            Action = "Update",
            UserId = 1, // Add user that created the role
            CreatedAt = DateTime.UtcNow,
            OldData = oldData,
            NewData = newData,
        };
        _activityLogRepository.Create(log);
        return NoContent();
    }

    [HttpPost]
    [ProducesResponseType(201, Type = typeof(RoleReadDto))]
    [ProducesResponseType(400)]
    public IActionResult CreateRole([FromBody] RoleCreateDto dto)
    {
        if (dto == null)
            return BadRequest("Invalid role data");
        if (dto.PermissionIds == null || !dto.PermissionIds.Any())
            return BadRequest("Role has to have at least one permission");
        var existingPermissions = _context.Permissions.Select(p => p.Id).ToList();
        var invalidPermissions = dto.PermissionIds.Except(existingPermissions).ToList();
        if (invalidPermissions.Any())
            return BadRequest($"Permissions with ids {string.Join(", ", invalidPermissions)} do not exist");
        if (_roleRepository.RoleExists(dto.Name))
            return BadRequest($"Role with name {dto.Name} already exists");
        var createdRole = new Role()
        {
            Name = dto.Name,
            CreatedAt = DateTime.UtcNow,
            RolePermissions = dto.PermissionIds.Select(pId => new RolePermission()
            {
                PermissionId = pId,
            }).ToList()
        };
        if (!_roleRepository.Create(createdRole))
            return BadRequest("Failed to create role");
        var fetchedRole = _roleRepository.GetRoleWithPermissions(createdRole.Id);
        if (fetchedRole == null)
            return NotFound($"Role with id {createdRole.Id} does not exist after creation");
        var roleReadDto = fetchedRole.ToReadDto();
        var newData = System.Text.Json.JsonSerializer.Serialize(roleReadDto);
        ActivityLog log = new ActivityLog()
        {
            ModuleId = (int)ModuleEnum.Roles,
            ComponentId = createdRole.Id,
            Action = "Create",
            UserId = 1, // Add user that created the role
            CreatedAt = DateTime.UtcNow,
            OldData = "",
            NewData = newData,
        };
        _activityLogRepository.Create(log);
        return CreatedAtAction(nameof(GetRoleById), new { id = createdRole.Id }, roleReadDto);
    }

    [HttpDelete("{id:int}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public IActionResult DeleteRole(int id)
    {
        var role = _roleRepository.GetRoleWithPermissions(id);
        if (role == null)
            return NotFound($"Role with id {id} does not exist");
        if (_roleRepository.HasUsers(role.Id)) 
            return BadRequest("Cannot delete role with users");
        var oldData = System.Text.Json.JsonSerializer.Serialize(role.ToReadDto());
        if (!_roleRepository.SoftDelete(role))
            return BadRequest("Failed to delete role");
        ActivityLog log = new ActivityLog()
        {
            ModuleId = (int)ModuleEnum.Roles,
            ComponentId = role.Id,
            Action = "Delete",
            UserId = 1, // Add user that created the role
            CreatedAt = DateTime.UtcNow,
            OldData = oldData,
            NewData = ""
        };

        _activityLogRepository.Create(log);
        return NoContent();
    }
}
