using HomeKeep.Models;
using Microsoft.AspNetCore.Mvc;

namespace HomeKeep.Controllers;

public class MaintenanceTasksController : Controller
{
    public IActionResult Index()
    {
        return View(MaintenanceTaskData.All);
    }
}