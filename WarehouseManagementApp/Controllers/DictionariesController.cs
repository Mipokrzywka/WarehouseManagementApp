using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WarehouseManagementApp.Data;
using WarehouseManagementApp.DTOs;
using WarehouseManagementApp.Models;

[Route("api/")]
[ApiController]
public class DictionariesController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    public DictionariesController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet("OrderStatuses")]
    [ProducesResponseType(200, Type = typeof(IEnumerable<OrderStatusReadDto>))]
    public IActionResult GetOrderStatuses()
    {
        var statuses = _context.OrderStatuses
            .AsNoTracking()
            .Select(s => new OrderStatusReadDto
            {
                Id = s.Id,
                Name = s.Name,
            }).ToList();
        return Ok(statuses);
    }
    [HttpGet("TaskStatuses")]
    [ProducesResponseType(200, Type = typeof(IEnumerable<TaskStatusReadDto>))]
    public IActionResult GetTaskStatuses()
    {
        var statuses = _context.TaskStatuses
            .AsNoTracking()
            .Select(s => new TaskStatusReadDto
            {
                Id = s.Id,
                Name = s.Name,
            }).ToList();
        return Ok(statuses);
    }
    [HttpGet("Permissions")]
    [ProducesResponseType(200, Type = typeof(IEnumerable<PermissionReadDto>))]
    public IActionResult GetPermissions()
    {
        var permissions = _context.Permissions
            .AsNoTracking()
            .Where(p => !p.Name.Equals("Access:All"))
            .Select(p => new PermissionReadDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description
            })            
            .ToList();
        return Ok(permissions);
    }
    [HttpGet("ActivityLogs(Test)")]
    [ProducesResponseType(200, Type = typeof(IEnumerable<ActivityLog>))]
    public IActionResult GetActivityLogs()
    {
        var activityLogs = _context.ActivityLogs
            .AsNoTracking()
            .ToList();
        return Ok(activityLogs);
    }
}