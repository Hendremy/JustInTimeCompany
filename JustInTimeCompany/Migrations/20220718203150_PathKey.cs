using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JustInTimeCompany.Migrations
{
    public partial class PathKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Aircrafts_AircraftId",
                table: "Flights");

            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Paths_PathFromId_PathToId",
                table: "Flights");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Paths",
                table: "Paths");

            migrationBuilder.DropIndex(
                name: "IX_Flights_PathFromId_PathToId",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "PathFromId",
                table: "Flights");

            migrationBuilder.RenameColumn(
                name: "PathToId",
                table: "Flights",
                newName: "PathId");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Paths",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "AircraftId",
                table: "Flights",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Paths",
                table: "Paths",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Paths_FromId",
                table: "Paths",
                column: "FromId");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_PathId",
                table: "Flights",
                column: "PathId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Aircrafts_AircraftId",
                table: "Flights");

            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Paths_PathId",
                table: "Flights");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Paths",
                table: "Paths");

            migrationBuilder.DropIndex(
                name: "IX_Paths_FromId",
                table: "Paths");

            migrationBuilder.DropIndex(
                name: "IX_Flights_PathId",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Paths");

            migrationBuilder.RenameColumn(
                name: "PathId",
                table: "Flights",
                newName: "PathToId");

            migrationBuilder.AlterColumn<int>(
                name: "AircraftId",
                table: "Flights",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PathFromId",
                table: "Flights",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Paths",
                table: "Paths",
                columns: new[] { "FromId", "ToId" });

            migrationBuilder.CreateIndex(
                name: "IX_Flights_PathFromId_PathToId",
                table: "Flights",
                columns: new[] { "PathFromId", "PathToId" });

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
        }
    }
}
