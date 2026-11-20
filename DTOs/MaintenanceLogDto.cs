
namespace HomeKeep.DTOs;

public class MaintenanceLogDto
{
    public int Id { get; set; }
    public DateTime CompletedOn { get; set; }
    public string PerformedBy { get; set; } = "";
    public string Notes { get; set; } = "";
}
