using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HomeKeep.Migrations
{
    /// <inheritdoc />
    public partial class AddMaintenanceLogs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MaintenanceLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompletedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PerformedBy = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    MaintenanceTaskId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintenanceLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaintenanceLogs_MaintenanceTasks_MaintenanceTaskId",
                        column: x => x.MaintenanceTaskId,
                        principalTable: "MaintenanceTasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "MaintenanceLogs",
                columns: new[] { "Id", "CompletedOn", "MaintenanceTaskId", "Notes", "PerformedBy" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Replaced the furnace filter and checked airflow.", "Jake" },
                    { 2, new DateTime(2026, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Removed the old filter and installed a new filter.", "Jake" },
                    { 3, new DateTime(2026, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Tested each smoke detector and confirmed alarms sounded.", "Jake" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceLogs_MaintenanceTaskId",
                table: "MaintenanceLogs",
                column: "MaintenanceTaskId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MaintenanceLogs");
        }
    }
}
