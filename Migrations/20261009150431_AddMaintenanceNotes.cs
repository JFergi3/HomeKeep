using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeKeep.Migrations
{
    /// <inheritdoc />
    public partial class AddMaintenanceNotes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MaintenanceNotes",
                table: "MaintenanceTasks",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "MaintenanceTasks",
                keyColumn: "Id",
                keyValue: 1,
                column: "MaintenanceNotes",
                value: null);

            migrationBuilder.UpdateData(
                table: "MaintenanceTasks",
                keyColumn: "Id",
                keyValue: 2,
                column: "MaintenanceNotes",
                value: null);

            migrationBuilder.UpdateData(
                table: "MaintenanceTasks",
                keyColumn: "Id",
                keyValue: 3,
                column: "MaintenanceNotes",
                value: null);

            migrationBuilder.UpdateData(
                table: "MaintenanceTasks",
                keyColumn: "Id",
                keyValue: 4,
                column: "MaintenanceNotes",
                value: null);

            migrationBuilder.UpdateData(
                table: "MaintenanceTasks",
                keyColumn: "Id",
                keyValue: 5,
                column: "MaintenanceNotes",
                value: null);

            migrationBuilder.UpdateData(
                table: "MaintenanceTasks",
                keyColumn: "Id",
                keyValue: 6,
                column: "MaintenanceNotes",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaintenanceNotes",
                table: "MaintenanceTasks");
        }
    }
}
