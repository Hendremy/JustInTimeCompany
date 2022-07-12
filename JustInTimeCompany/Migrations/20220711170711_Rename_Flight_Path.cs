using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JustInTimeCompany.Migrations
{
    public partial class Rename_Flight_Path : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_FlightInstances_FlightInstanceId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_FlightReport_FlightInstances_FlightInstanceId",
                table: "FlightReport");

            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Airports_FromId",
                table: "Flights");

            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Airports_ToId",
                table: "Flights");

            migrationBuilder.DropTable(
                name: "FlightInstances");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Flights",
                table: "Flights");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_FlightInstanceId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "FlightInstanceId",
                table: "Bookings");

            migrationBuilder.RenameColumn(
                name: "ToId",
                table: "Flights",
                newName: "ScheduleId");

            migrationBuilder.RenameColumn(
                name: "FromId",
                table: "Flights",
                newName: "PilotId");

            migrationBuilder.RenameIndex(
                name: "IX_Flights_ToId",
                table: "Flights",
                newName: "IX_Flights_ScheduleId");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Flights",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "AircraftId",
                table: "Flights",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PathFromId",
                table: "Flights",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PathToId",
                table: "Flights",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Flights",
                table: "Flights",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Paths",
                columns: table => new
                {
                    FromId = table.Column<int>(type: "int", nullable: false),
                    ToId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paths", x => new { x.FromId, x.ToId });
                    table.ForeignKey(
                        name: "FK_Paths_Airports_FromId",
                        column: x => x.FromId,
                        principalTable: "Airports",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Paths_Airports_ToId",
                        column: x => x.ToId,
                        principalTable: "Airports",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Flights_AircraftId",
                table: "Flights",
                column: "AircraftId");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_PathFromId_PathToId",
                table: "Flights",
                columns: new[] { "PathFromId", "PathToId" });

            migrationBuilder.CreateIndex(
                name: "IX_Flights_PilotId",
                table: "Flights",
                column: "PilotId");

            migrationBuilder.CreateIndex(
                name: "IX_Paths_ToId",
                table: "Paths",
                column: "ToId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Flights_FlightId",
                table: "Bookings",
                column: "FlightId",
                principalTable: "Flights",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FlightReport_Flights_FlightInstanceId",
                table: "FlightReport",
                column: "FlightInstanceId",
                principalTable: "Flights",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Aircrafts_AircraftId",
                table: "Flights",
                column: "AircraftId",
                principalTable: "Aircrafts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Paths_PathFromId_PathToId",
                table: "Flights",
                columns: new[] { "PathFromId", "PathToId" },
                principalTable: "Paths",
                principalColumns: new[] { "FromId", "ToId" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Pilots_PilotId",
                table: "Flights",
                column: "PilotId",
                principalTable: "Pilots",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Schedule_ScheduleId",
                table: "Flights",
                column: "ScheduleId",
                principalTable: "Schedule",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Flights_FlightId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_FlightReport_Flights_FlightInstanceId",
                table: "FlightReport");

            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Aircrafts_AircraftId",
                table: "Flights");

            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Paths_PathFromId_PathToId",
                table: "Flights");

            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Pilots_PilotId",
                table: "Flights");

            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Schedule_ScheduleId",
                table: "Flights");

            migrationBuilder.DropTable(
                name: "Paths");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Flights",
                table: "Flights");

            migrationBuilder.DropIndex(
                name: "IX_Flights_AircraftId",
                table: "Flights");

            migrationBuilder.DropIndex(
                name: "IX_Flights_PathFromId_PathToId",
                table: "Flights");

            migrationBuilder.DropIndex(
                name: "IX_Flights_PilotId",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "AircraftId",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "PathFromId",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "PathToId",
                table: "Flights");

            migrationBuilder.RenameColumn(
                name: "ScheduleId",
                table: "Flights",
                newName: "ToId");

            migrationBuilder.RenameColumn(
                name: "PilotId",
                table: "Flights",
                newName: "FromId");

            migrationBuilder.RenameIndex(
                name: "IX_Flights_ScheduleId",
                table: "Flights",
                newName: "IX_Flights_ToId");

            migrationBuilder.AddColumn<int>(
                name: "FlightInstanceId",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Flights",
                table: "Flights",
                columns: new[] { "FromId", "ToId" });

            migrationBuilder.CreateTable(
                name: "FlightInstances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AircraftId = table.Column<int>(type: "int", nullable: false),
                    FlightFromId = table.Column<int>(type: "int", nullable: false),
                    PilotId = table.Column<int>(type: "int", nullable: false),
                    ScheduleId = table.Column<int>(type: "int", nullable: false),
                    FlightToId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightInstances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FlightInstances_Aircrafts_AircraftId",
                        column: x => x.AircraftId,
                        principalTable: "Aircrafts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FlightInstances_Flights_FlightFromId_FlightToId",
                        columns: x => new { x.FlightFromId, x.FlightToId },
                        principalTable: "Flights",
                        principalColumns: new[] { "FromId", "ToId" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FlightInstances_Pilots_PilotId",
                        column: x => x.PilotId,
                        principalTable: "Pilots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FlightInstances_Schedule_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "Schedule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_FlightInstanceId",
                table: "Bookings",
                column: "FlightInstanceId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightInstances_AircraftId",
                table: "FlightInstances",
                column: "AircraftId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightInstances_FlightFromId_FlightToId",
                table: "FlightInstances",
                columns: new[] { "FlightFromId", "FlightToId" });

            migrationBuilder.CreateIndex(
                name: "IX_FlightInstances_PilotId",
                table: "FlightInstances",
                column: "PilotId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightInstances_ScheduleId",
                table: "FlightInstances",
                column: "ScheduleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_FlightInstances_FlightInstanceId",
                table: "Bookings",
                column: "FlightInstanceId",
                principalTable: "FlightInstances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FlightReport_FlightInstances_FlightInstanceId",
                table: "FlightReport",
                column: "FlightInstanceId",
                principalTable: "FlightInstances",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Airports_FromId",
                table: "Flights",
                column: "FromId",
                principalTable: "Airports",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Airports_ToId",
                table: "Flights",
                column: "ToId",
                principalTable: "Airports",
                principalColumn: "Id");
        }
    }
}
