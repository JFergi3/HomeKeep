using Microsoft.EntityFrameworkCore;
using HomeKeep.Models;

namespace HomeKeep.Data;

public class HomeKeepContext : DbContext
{
    public HomeKeepContext(DbContextOptions<HomeKeepContext> options)
        : base(options)
    {
    }

    public DbSet<MaintenanceTask> MaintenanceTasks => Set<MaintenanceTask>();
}