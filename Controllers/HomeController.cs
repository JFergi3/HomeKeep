using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using HomeKeep.Models;
using HomeKeep.Data;

namespace HomeKeep.Controllers;

public class HomeController : Controller
{
    private readonly HomeKeepContext _context;

    public HomeController(HomeKeepContext context)
    {
        _context = context;
    }
    public IActionResult Index()
    {
        var featured = _context.MaintenanceTasks
            .OrderBy(task => task.Id)
            .FirstOrDefault();

        return View(featured);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
