using HomeKeep.Models;
using Microsoft.AspNetCore.Mvc;

namespace HomeKeep.Controllers;

public class MaintenanceTasksController : Controller
{
    public IActionResult Index()
    {
        return View(MaintenanceTaskData.All);
    }

    public IActionResult Details(int id)
    {
        MaintenanceTask? task = MaintenanceTaskData.All
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

        task.Id = MaintenanceTaskData.All.Max(item => item.Id) + 1;
        MaintenanceTaskData.All.Add(task);

        return RedirectToAction(nameof(Index));
    }
}