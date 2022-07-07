using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JustInTimeCompany.Migrations
{
    public partial class EngineInAircraft : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Engine_AircraftModels_AircraftModelId",
                table: "Engine");

            migrationBuilder.DropIndex(
                name: "IX_Engine_AircraftModelId",
                table: "Engine");

            migrationBuilder.DropColumn(
                name: "AircraftModelId",
                table: "Engine");

            migrationBuilder.CreateTable(
                name: "EngineInAircraft",
                columns: table => new
                {
                    ModelId = table.Column<int>(type: "int", nullable: false),
                    EngineId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EngineInAircraft", x => new { x.EngineId, x.ModelId });
                    table.ForeignKey(
                        name: "FK_EngineInAircraft_AircraftModels_ModelId",
                        column: x => x.ModelId,
                        principalTable: "AircraftModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EngineInAircraft_Engine_EngineId",
                        column: x => x.EngineId,
                        principalTable: "Engine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EngineInAircraft_ModelId",
                table: "EngineInAircraft",
                column: "ModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EngineInAircraft");

            migrationBuilder.AddColumn<int>(
                name: "AircraftModelId",
                table: "Engine",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Engine_AircraftModelId",
                table: "Engine",
                column: "AircraftModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Engine_AircraftModels_AircraftModelId",
                table: "Engine",
                column: "AircraftModelId",
                principalTable: "AircraftModels",
                principalColumn: "Id");
        }
    }
}
