using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JustInTimeCompany.Migrations
{
    public partial class ModifLog_FLightId_Move : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FlightId",
                table: "FlightArchive");

            migrationBuilder.AddColumn<int>(
                name: "FlightId",
                table: "Modifications",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FlightId",
                table: "Modifications");

            migrationBuilder.AddColumn<int>(
                name: "FlightId",
                table: "FlightArchive",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
