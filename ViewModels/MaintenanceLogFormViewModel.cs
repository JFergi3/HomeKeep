using HomeKeep.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HomeKeep.ViewModels;

public class MaintenanceLogFormViewModel
{
    public MaintenanceLog MaintenanceLog { get; set; } = new();

    public SelectList? MaintenanceTasks { get; set; }
}