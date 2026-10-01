using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HomeKeep.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MaintenanceTasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Room = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    FrequencyDays = table.Column<int>(type: "int", nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintenanceTasks", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "MaintenanceTasks",
                columns: new[] { "Id", "Description", "FrequencyDays", "IsCompleted", "Name", "Room" },
                values: new object[,]
                {
                    { 1, "Replace the HVAC filter to maintain airflow and indoor air quality.", 90, false, "Replace furnace filter", "Basement" },
                    { 2, "Test each detector and replace weak or expired batteries.", 30, true, "Test smoke detectors", "Entire Home" },
                    { 3, "Remove lint from the dryer vent and inspect the exhaust connection.", 180, false, "Clean dryer vent", "Laundry Room" },
                    { 4, "Check supply lines, drains, and cabinet surfaces for signs of leaks.", 90, false, "Inspect under-sink plumbing", "Kitchen" },
                    { 5, "Remove dust from the refrigerator coils to improve efficiency.", 180, true, "Clean refrigerator coils", "Kitchen" },
                    { 6, "Inspect the water heater and surrounding area for leaks or corrosion.", 90, false, "Check water heater", "Basement" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MaintenanceTasks");
        }
    }
}
