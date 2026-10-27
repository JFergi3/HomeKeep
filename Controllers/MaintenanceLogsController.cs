using HomeKeep.Data;
using HomeKeep.Models;
using HomeKeep.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HomeKeep.Controllers;

public class MaintenanceLogsController : Controller
{
    private readonly HomeKeepContext _context;

    public MaintenanceLogsController(HomeKeepContext context)
    {
        _context = context;
    }

    public IActionResult Create(int? maintenanceTaskId)
    {
        var form = new MaintenanceLogFormViewModel
        {
            MaintenanceLog = new MaintenanceLog
            {
                MaintenanceTaskId = maintenanceTaskId ?? 0,
                CompletedOn = DateTime.Today
            },
            MaintenanceTasks = TaskChoices(maintenanceTaskId)
        };

        return View(form);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(MaintenanceLogFormViewModel form)
    {
        if (!ModelState.IsValid)
        {
            form.MaintenanceTasks =
                TaskChoices(form.MaintenanceLog.MaintenanceTaskId);

            return View(form);
        }

        _context.MaintenanceLogs.Add(form.MaintenanceLog);
        _context.SaveChanges();

        return RedirectToAction(
            "Details",
            "MaintenanceTasks",
            new { id = form.MaintenanceLog.MaintenanceTaskId });
    }

    private SelectList TaskChoices(int? selected) =>
        new SelectList(
            _context.MaintenanceTasks.OrderBy(task => task.Name).ToList(),
            "Id",
            "Name",
            selected);
}