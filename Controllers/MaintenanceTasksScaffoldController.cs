using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HomeKeep.Data;
using HomeKeep.Models;

namespace HomeKeep.Controllers
{
    public class MaintenanceTasksScaffoldController : Controller
    {
        private readonly HomeKeepContext _context;

        public MaintenanceTasksScaffoldController(HomeKeepContext context)
        {
            _context = context;
        }

        // GET: MaintenanceTasksScaffold
        public async Task<IActionResult> Index()
        {
            return View(await _context.MaintenanceTasks.ToListAsync());
        }

        // GET: MaintenanceTasksScaffold/Details/5
        public async Task<IActionResult> Details(int? id)
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

        // GET: MaintenanceTasksScaffold/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MaintenanceTasksScaffold/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Room,FrequencyDays,IsCompleted")] MaintenanceTask maintenanceTask)
        {
            if (ModelState.IsValid)
            {
                _context.Add(maintenanceTask);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(maintenanceTask);
        }

        // GET: MaintenanceTasksScaffold/Edit/5
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

        // POST: MaintenanceTasksScaffold/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Room,FrequencyDays,IsCompleted")] MaintenanceTask maintenanceTask)
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

        // GET: MaintenanceTasksScaffold/Delete/5
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

        // POST: MaintenanceTasksScaffold/Delete/5
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

        private bool MaintenanceTaskExists(int id)
        {
            return _context.MaintenanceTasks.Any(e => e.Id == id);
        }
    }
}
