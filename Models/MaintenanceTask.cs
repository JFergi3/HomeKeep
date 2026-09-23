using System.ComponentModel.DataAnnotations;
namespace HomeKeep.Models;

public class MaintenanceTask
{
    public int Id { get; set; }
    [Required]
    [StringLength(60, MinimumLength = 2)]
    public string Name { get; set; } = "";

    [StringLength(500)]
    public string Description { get; set; } = "";

    [Required]
    [StringLength(60)]
    public string Room { get; set; } = "";

    [Display(Name = "Frequency (days)")]
    [Range(1, 3650)]
    public int FrequencyDays { get; set; }
    public bool IsCompleted { get; set; }
}