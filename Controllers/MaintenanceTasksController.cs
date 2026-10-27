using HomeKeep.Data;
using HomeKeep.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

     // GET: MaintenanceTasks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var maintenanceTask = await _context.MaintenanceTasks.FindAsync(id);
            if (maintenanceTask == null)
            {
                return NotFound();
            }
            return View(maintenanceTask);
        }

        // POST: MaintenanceTasks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Room,FrequencyDays,IsCompleted,MaintenanceNotes")] MaintenanceTask maintenanceTask)
        {
            if (id != maintenanceTask.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(maintenanceTask);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MaintenanceTaskExists(maintenanceTask.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(maintenanceTask);
        }

         private bool MaintenanceTaskExists(int id)
        {
            return _context.MaintenanceTasks.Any(e => e.Id == id);
        }

           // GET: MaintenanceTasks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var maintenanceTask = await _context.MaintenanceTasks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (maintenanceTask == null)
            {
                return NotFound();
            }

            return View(maintenanceTask);
        }

        // POST: MaintenanceTasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var maintenanceTask = await _context.MaintenanceTasks.FindAsync(id);
            if (maintenanceTask != null)
            {
                _context.MaintenanceTasks.Remove(maintenanceTask);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
}

///TEST