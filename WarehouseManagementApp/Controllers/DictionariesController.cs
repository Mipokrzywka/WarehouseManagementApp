using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WarehouseManagementApp.Data;
using WarehouseManagementApp.DTOs;
using WarehouseManagementApp.Models;

[Route("api/[controller]")]
[ApiController]
public class DictionariesController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    public DictionariesController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet("order-status")]
    [ProducesResponseType(200, Type = typeof(IEnumerable<OrderStatusReadDto>))]
    public IActionResult GetOrderStatuses()
    {
        var statuses = _context.OrderStatuses.Select(s => new OrderStatusReadDto 
        {
            Id = s.Id,
            Name = s.Name,
        }).ToList();
        return Ok(statuses);
    }
    [HttpGet("task-status")]
    [ProducesResponseType(200, Type = typeof(IEnumerable<TaskStatusReadDto>))]
    public IActionResult GetTaskStatuses()
    {
        var statuses = _context.TaskStatuses.Select(s => new TaskStatusReadDto
        {
            Id = s.Id,
            Name = s.Name,
        }).ToList();
        return Ok(statuses);
    }


}
