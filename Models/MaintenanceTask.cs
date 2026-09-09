namespace HomeKeep.Models;

public class MaintenanceTask
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Room { get; set; } = "";
    public int FrequencyDays { get; set; }
    public string Difficulty { get; set; } = "";
    public bool IsCompleted { get; set; }
}