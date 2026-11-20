
using System.ComponentModel.DataAnnotations;

namespace HomeKeep.DTOs;

public class MaintenanceTaskInput
{
    [Required]
    [StringLength(60, MinimumLength = 2)]
    public string Name { get; set; } = "";

    [StringLength(500)]
    public string Description { get; set; } = "";

    [Required]
    [StringLength(60)]
    public string Room { get; set; } = "";

    [Range(1, 3650)]
    public int FrequencyDays { get; set; }

    public bool IsCompleted { get; set; }

    [StringLength(500)]
    public string? MaintenanceNotes { get; set; }
}
