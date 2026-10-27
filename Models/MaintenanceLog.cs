using System.ComponentModel.DataAnnotations;

namespace HomeKeep.Models;

public class MaintenanceLog
{
    public int Id { get; set; }

    [Display(Name = "Completed on")]
    [DataType(DataType.Date)]
    public DateTime CompletedOn { get; set; }

    [Required]
    [Display(Name = "Performed by")]
    [StringLength(60, MinimumLength = 2)]
    public string PerformedBy { get; set; } = "";

    [Required]
    [StringLength(400, MinimumLength = 10,
        ErrorMessage = "Enter between {2} and {1} characters.")]
    public string Notes { get; set; } = "";

    [Display(Name = "Maintenance task")]
    public int MaintenanceTaskId { get; set; }

    public MaintenanceTask? MaintenanceTask { get; set; }
}