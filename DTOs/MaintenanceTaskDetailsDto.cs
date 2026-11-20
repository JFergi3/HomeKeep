
namespace HomeKeep.DTOs;

public class MaintenanceTaskDetailsDto
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Description { get; set; } = "";
    public string Room { get; set; } = "";
    public int FrequencyDays { get; set; }
    public bool IsCompleted { get; set; }
    public string? MaintenanceNotes { get; set; }

    public List<MaintenanceLogDto> MaintenanceLogs { get; set; } = new();
}
