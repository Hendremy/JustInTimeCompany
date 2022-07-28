using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JustInTimeCompany.Migrations
{
    public partial class ModificationLogs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Aircrafts_AircraftId",
                table: "Flights");

            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Paths_PathId",
                table: "Flights");

            migrationBuilder.AlterColumn<int>(
                name: "PathId",
                table: "Flights",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AircraftId",
                table: "Flights",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Modifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FlightArchive",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PilotId = table.Column<int>(type: "int", nullable: false),
                    PathId = table.Column<int>(type: "int", nullable: false),
                    ScheduleId = table.Column<int>(type: "int", nullable: false),
                    AircradtId = table.Column<int>(type: "int", nullable: false),
                    AircraftId = table.Column<int>(type: "int", nullable: false),
                    BeforeLogId = table.Column<int>(type: "int", nullable: true),
                    AfterLogId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightArchive", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FlightArchive_Aircrafts_AircraftId",
                        column: x => x.AircraftId,
                        principalTable: "Aircrafts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FlightArchive_Modifications_AfterLogId",
                        column: x => x.AfterLogId,
                        principalTable: "Modifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FlightArchive_Modifications_BeforeLogId",
                        column: x => x.BeforeLogId,
                        principalTable: "Modifications",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FlightArchive_Paths_PathId",
                        column: x => x.PathId,
                        principalTable: "Paths",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FlightArchive_Pilots_PilotId",
                        column: x => x.PilotId,
                        principalTable: "Pilots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FlightArchive_Schedule_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "Schedule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FlightArchive_AfterLogId",
                table: "FlightArchive",
                column: "AfterLogId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FlightArchive_AircraftId",
                table: "FlightArchive",
                column: "AircraftId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightArchive_BeforeLogId",
                table: "FlightArchive",
                column: "BeforeLogId",
                unique: true,
                filter: "[BeforeLogId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_FlightArchive_PathId",
                table: "FlightArchive",
                column: "PathId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightArchive_PilotId",
                table: "FlightArchive",
                column: "PilotId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightArchive_ScheduleId",
                table: "FlightArchive",
                column: "ScheduleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Aircrafts_AircraftId",
                table: "Flights",
                column: "AircraftId",
                principalTable: "Aircrafts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Paths_PathId",
                table: "Flights",
                column: "PathId",
                principalTable: "Paths",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Aircrafts_AircraftId",
                table: "Flights");

            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Paths_PathId",
                table: "Flights");

            migrationBuilder.DropTable(
                name: "FlightArchive");

            migrationBuilder.DropTable(
                name: "Modifications");

            migrationBuilder.AlterColumn<int>(
                name: "PathId",
                table: "Flights",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AircraftId",
                table: "Flights",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Aircrafts_AircraftId",
                table: "Flights",
                column: "AircraftId",
                principalTable: "Aircrafts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Paths_PathId",
                table: "Flights",
                column: "PathId",
                principalTable: "Paths",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
