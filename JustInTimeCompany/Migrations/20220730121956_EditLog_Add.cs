using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JustInTimeCompany.Migrations
{
    public partial class EditLog_Add : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FlightArchive",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PilotId = table.Column<int>(type: "int", nullable: false),
                    PathId = table.Column<int>(type: "int", nullable: false),
                    ScheduleId = table.Column<int>(type: "int", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "EditLogs",
                columns: table => new
                {
                    BeforeId = table.Column<int>(type: "int", nullable: false),
                    AfterId = table.Column<int>(type: "int", nullable: false),
                    FlightId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EditLogs", x => new { x.BeforeId, x.AfterId });
                    table.ForeignKey(
                        name: "FK_EditLogs_FlightArchive_AfterId",
                        column: x => x.AfterId,
                        principalTable: "FlightArchive",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EditLogs_FlightArchive_BeforeId",
                        column: x => x.BeforeId,
                        principalTable: "FlightArchive",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EditLogs_Flights_FlightId",
                        column: x => x.FlightId,
                        principalTable: "Flights",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EditLogs_AfterId",
                table: "EditLogs",
                column: "AfterId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EditLogs_BeforeId",
                table: "EditLogs",
                column: "BeforeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EditLogs_FlightId",
                table: "EditLogs",
                column: "FlightId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightArchive_AircraftId",
                table: "FlightArchive",
                column: "AircraftId");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EditLogs");

            migrationBuilder.DropTable(
                name: "FlightArchive");
        }
    }
}
