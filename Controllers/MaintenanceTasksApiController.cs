
using HomeKeep.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HomeKeep.Controllers;

[ApiController]
[Route("api/MaintenanceTasks")]
public class MaintenanceTasksApiController : ControllerBase
{
    private readonly HomeKeepContext _context;

    public MaintenanceTasksApiController(HomeKeepContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetMaintenanceTasks()
    {
        var tasks = await _context.MaintenanceTasks
            .AsNoTracking()
            .ToListAsync();

        return Ok(tasks);
    }
}
