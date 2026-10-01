using HomeKeep.Data;
using HomeKeep.Models;
using Microsoft.AspNetCore.Mvc;

namespace HomeKeep.Controllers;

public class MaintenanceTasksController : Controller
{
    private readonly HomeKeepContext _context;

    public MaintenanceTasksController(HomeKeepContext context)
    {
        _context = context;
    }
    public IActionResult Index()
    {
        return View(_context.MaintenanceTasks.ToList());
    }

    public IActionResult Details(int id)
    {
        MaintenanceTask? task = _context.MaintenanceTasks
            .FirstOrDefault(task => task.Id == id);

        if (task == null)
        {
            return NotFound();
        }

        return View(task);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(MaintenanceTask task)
    {
        if (!ModelState.IsValid)
        {
            return View(task);
        }

        _context.MaintenanceTasks.Add(task);
        _context.SaveChanges();

        return RedirectToAction(nameof(Index));
    }
}