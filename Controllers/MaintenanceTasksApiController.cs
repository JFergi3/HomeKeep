
using HomeKeep.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HomeKeep.DTOs;
using Microsoft.AspNetCore.Authorization;
using HomeKeep.Models;

namespace HomeKeep.Controllers;


[ApiController]
[Route("api/MaintenanceTasks")]
[Authorize(Roles = "Manager")]
public class MaintenanceTasksApiController : ControllerBase
{
    private readonly HomeKeepContext _context;

    public MaintenanceTasksApiController(HomeKeepContext context)
    {
        _context = context;
    }

    [AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> GetMaintenanceTasks()
    {
        var tasks = await _context.MaintenanceTasks
            .AsNoTracking()
            .Select(task => new MaintenanceTaskDto
            {
                Id = task.Id,
                Name = task.Name,
                Description = task.Description,
                Room = task.Room,
                FrequencyDays = task.FrequencyDays,
                IsCompleted = task.IsCompleted,
                MaintenanceNotes = task.MaintenanceNotes
            })
            .ToListAsync();

        return Ok(tasks);
    }

    [AllowAnonymous]
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetMaintenanceTask(int id)
    {
        var task = await _context.MaintenanceTasks
            .AsNoTracking()
            .Include(task => task.MaintenanceLogs)
            .FirstOrDefaultAsync(task => task.Id == id);

        if (task == null)
        {
            return NotFound();
        }

        var details = new MaintenanceTaskDetailsDto
        {
            Id = task.Id,
            Name = task.Name,
            Description = task.Description,
            Room = task.Room,
            FrequencyDays = task.FrequencyDays,
            IsCompleted = task.IsCompleted,
            MaintenanceNotes = task.MaintenanceNotes,
            MaintenanceLogs = task.MaintenanceLogs
                .Select(log => new MaintenanceLogDto
                {
                    Id = log.Id,
                    CompletedOn = log.CompletedOn,
                    PerformedBy = log.PerformedBy,
                    Notes = log.Notes
                })
                .ToList()
        };

        return Ok(details);
    }

    [HttpPost]
    public async Task<IActionResult> CreateMaintenanceTask(
        [FromBody] MaintenanceTaskInput input)
    {
        var task = new MaintenanceTask
        {
            Name = input.Name,
            Description = input.Description,
            Room = input.Room,
            FrequencyDays = input.FrequencyDays,
            IsCompleted = input.IsCompleted,
            MaintenanceNotes = input.MaintenanceNotes
        };

        _context.MaintenanceTasks.Add(task);
        await _context.SaveChangesAsync();

        return CreatedAtAction(
            nameof(GetMaintenanceTask),
            new { id = task.Id },
            new MaintenanceTaskDto
            {
                Id = task.Id,
                Name = task.Name,
                Description = task.Description,
                Room = task.Room,
                FrequencyDays = task.FrequencyDays,
                IsCompleted = task.IsCompleted,
                MaintenanceNotes = task.MaintenanceNotes
            });
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteMaintenanceTask(int id)
    {
        var task = await _context.MaintenanceTasks
            .FindAsync(id);

        if (task == null)
        {
            return NotFound();
        }

        _context.MaintenanceTasks.Remove(task);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
