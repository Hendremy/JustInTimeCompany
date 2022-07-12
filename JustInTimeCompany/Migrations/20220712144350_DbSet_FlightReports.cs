using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JustInTimeCompany.Migrations
{
    public partial class DbSet_FlightReports : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FlightReport_Flights_FlightInstanceId",
                table: "FlightReport");

            migrationBuilder.DropForeignKey(
                name: "FK_FlightReport_Schedule_ActualScheduleId",
                table: "FlightReport");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FlightReport",
                table: "FlightReport");

            migrationBuilder.RenameTable(
                name: "FlightReport",
                newName: "FlightReports");

            migrationBuilder.RenameColumn(
                name: "FlightInstanceId",
                table: "FlightReports",
                newName: "FlightId");

            migrationBuilder.RenameIndex(
                name: "IX_FlightReport_FlightInstanceId",
                table: "FlightReports",
                newName: "IX_FlightReports_FlightId");

            migrationBuilder.RenameIndex(
                name: "IX_FlightReport_ActualScheduleId",
                table: "FlightReports",
                newName: "IX_FlightReports_ActualScheduleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FlightReports",
                table: "FlightReports",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FlightReports_Flights_FlightId",
                table: "FlightReports",
                column: "FlightId",
                principalTable: "Flights",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FlightReports_Schedule_ActualScheduleId",
                table: "FlightReports",
                column: "ActualScheduleId",
                principalTable: "Schedule",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FlightReports_Flights_FlightId",
                table: "FlightReports");

            migrationBuilder.DropForeignKey(
                name: "FK_FlightReports_Schedule_ActualScheduleId",
                table: "FlightReports");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FlightReports",
                table: "FlightReports");

            migrationBuilder.RenameTable(
                name: "FlightReports",
                newName: "FlightReport");

            migrationBuilder.RenameColumn(
                name: "FlightId",
                table: "FlightReport",
                newName: "FlightInstanceId");

            migrationBuilder.RenameIndex(
                name: "IX_FlightReports_FlightId",
                table: "FlightReport",
                newName: "IX_FlightReport_FlightInstanceId");

            migrationBuilder.RenameIndex(
                name: "IX_FlightReports_ActualScheduleId",
                table: "FlightReport",
                newName: "IX_FlightReport_ActualScheduleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FlightReport",
                table: "FlightReport",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FlightReport_Flights_FlightInstanceId",
                table: "FlightReport",
                column: "FlightInstanceId",
                principalTable: "Flights",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FlightReport_Schedule_ActualScheduleId",
                table: "FlightReport",
                column: "ActualScheduleId",
                principalTable: "Schedule",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
