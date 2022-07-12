using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JustInTimeCompany.Migrations
{
    public partial class DbSet_FlightInstances : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_FlightInstance_FlightInstanceId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_FlightInstance_Aircrafts_AircraftId",
                table: "FlightInstance");

            migrationBuilder.DropForeignKey(
                name: "FK_FlightInstance_Flights_FlightFromId_FlightToId",
                table: "FlightInstance");

            migrationBuilder.DropForeignKey(
                name: "FK_FlightInstance_Pilots_PilotId",
                table: "FlightInstance");

            migrationBuilder.DropForeignKey(
                name: "FK_FlightInstance_Schedule_ScheduleId",
                table: "FlightInstance");

            migrationBuilder.DropForeignKey(
                name: "FK_FlightReport_FlightInstance_FlightInstanceId",
                table: "FlightReport");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FlightInstance",
                table: "FlightInstance");

            migrationBuilder.RenameTable(
                name: "FlightInstance",
                newName: "FlightInstances");

            migrationBuilder.RenameIndex(
                name: "IX_FlightInstance_ScheduleId",
                table: "FlightInstances",
                newName: "IX_FlightInstances_ScheduleId");

            migrationBuilder.RenameIndex(
                name: "IX_FlightInstance_PilotId",
                table: "FlightInstances",
                newName: "IX_FlightInstances_PilotId");

            migrationBuilder.RenameIndex(
                name: "IX_FlightInstance_FlightFromId_FlightToId",
                table: "FlightInstances",
                newName: "IX_FlightInstances_FlightFromId_FlightToId");

            migrationBuilder.RenameIndex(
                name: "IX_FlightInstance_AircraftId",
                table: "FlightInstances",
                newName: "IX_FlightInstances_AircraftId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FlightInstances",
                table: "FlightInstances",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_FlightInstances_FlightInstanceId",
                table: "Bookings",
                column: "FlightInstanceId",
                principalTable: "FlightInstances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FlightInstances_Aircrafts_AircraftId",
                table: "FlightInstances",
                column: "AircraftId",
                principalTable: "Aircrafts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FlightInstances_Flights_FlightFromId_FlightToId",
                table: "FlightInstances",
                columns: new[] { "FlightFromId", "FlightToId" },
                principalTable: "Flights",
                principalColumns: new[] { "FromId", "ToId" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FlightInstances_Pilots_PilotId",
                table: "FlightInstances",
                column: "PilotId",
                principalTable: "Pilots",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FlightInstances_Schedule_ScheduleId",
                table: "FlightInstances",
                column: "ScheduleId",
                principalTable: "Schedule",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FlightReport_FlightInstances_FlightInstanceId",
                table: "FlightReport",
                column: "FlightInstanceId",
                principalTable: "FlightInstances",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_FlightInstances_FlightInstanceId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_FlightInstances_Aircrafts_AircraftId",
                table: "FlightInstances");

            migrationBuilder.DropForeignKey(
                name: "FK_FlightInstances_Flights_FlightFromId_FlightToId",
                table: "FlightInstances");

            migrationBuilder.DropForeignKey(
                name: "FK_FlightInstances_Pilots_PilotId",
                table: "FlightInstances");

            migrationBuilder.DropForeignKey(
                name: "FK_FlightInstances_Schedule_ScheduleId",
                table: "FlightInstances");

            migrationBuilder.DropForeignKey(
                name: "FK_FlightReport_FlightInstances_FlightInstanceId",
                table: "FlightReport");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FlightInstances",
                table: "FlightInstances");

            migrationBuilder.RenameTable(
                name: "FlightInstances",
                newName: "FlightInstance");

            migrationBuilder.RenameIndex(
                name: "IX_FlightInstances_ScheduleId",
                table: "FlightInstance",
                newName: "IX_FlightInstance_ScheduleId");

            migrationBuilder.RenameIndex(
                name: "IX_FlightInstances_PilotId",
                table: "FlightInstance",
                newName: "IX_FlightInstance_PilotId");

            migrationBuilder.RenameIndex(
                name: "IX_FlightInstances_FlightFromId_FlightToId",
                table: "FlightInstance",
                newName: "IX_FlightInstance_FlightFromId_FlightToId");

            migrationBuilder.RenameIndex(
                name: "IX_FlightInstances_AircraftId",
                table: "FlightInstance",
                newName: "IX_FlightInstance_AircraftId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FlightInstance",
                table: "FlightInstance",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_FlightInstance_FlightInstanceId",
                table: "Bookings",
                column: "FlightInstanceId",
                principalTable: "FlightInstance",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FlightInstance_Aircrafts_AircraftId",
                table: "FlightInstance",
                column: "AircraftId",
                principalTable: "Aircrafts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FlightInstance_Flights_FlightFromId_FlightToId",
                table: "FlightInstance",
                columns: new[] { "FlightFromId", "FlightToId" },
                principalTable: "Flights",
                principalColumns: new[] { "FromId", "ToId" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FlightInstance_Pilots_PilotId",
                table: "FlightInstance",
                column: "PilotId",
                principalTable: "Pilots",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FlightInstance_Schedule_ScheduleId",
                table: "FlightInstance",
                column: "ScheduleId",
                principalTable: "Schedule",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FlightReport_FlightInstance_FlightInstanceId",
                table: "FlightReport",
                column: "FlightInstanceId",
                principalTable: "FlightInstance",
                principalColumn: "Id");
        }
    }
}
