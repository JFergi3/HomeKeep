using System.Data.Common;

namespace HomeKeep.Models;

public static class MaintenanceTaskData
{
    public static List<MaintenanceTask> All { get; } = new()
    {
        new MaintenanceTask
        {
            Id = 1,
            Name = "Replace furnace filter",
            Description = "Replace the HVAC filter to maintain airflow and indoor air quality.",
            Room = "Basement",
            FrequencyDays = 90,
            IsCompleted = false
        },
         new MaintenanceTask
        {
            Id = 2,
            Name = "Test smoke detectors",
            Description = "Test each detector and replace weak or expired batteries.",
            Room = "Entire Home",
            FrequencyDays = 30,
            IsCompleted = true
        },
         new MaintenanceTask
        {
            Id = 3,
           Name = "Clean dryer vent",
            Description = "Remove lint from the dryer vent and inspect the exhaust connection.",
            Room = "Laundry Room",
            FrequencyDays = 180,
            IsCompleted = false
        },
         new MaintenanceTask
        {
            Id = 4,
           Name = "Inspect under-sink plumbing",
            Description = "Check supply lines, drains, and cabinet surfaces for signs of leaks.",
            Room = "Kitchen",
            FrequencyDays = 90,
            IsCompleted = false
        },
         new MaintenanceTask
        {
            Id = 5,
           Name = "Clean refrigerator coils",
            Description = "Remove dust from the refrigerator coils to improve efficiency.",
            Room = "Kitchen",
            FrequencyDays = 180,
            IsCompleted = true
        },
         new MaintenanceTask
        {
            Id = 6,
              Name = "Check water heater",
            Description = "Inspect the water heater and surrounding area for leaks or corrosion.",
            Room = "Basement",
            FrequencyDays = 90,
            IsCompleted = false
        }
    };
}