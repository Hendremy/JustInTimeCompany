using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JustInTimeCompany.Migrations
{
    public partial class Airport_AddLocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Airports",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Airports",
                keyColumn: "Id",
                keyValue: 1,
                column: "Location",
                value: "Liège");

            migrationBuilder.UpdateData(
                table: "Airports",
                keyColumn: "Id",
                keyValue: 2,
                column: "Location",
                value: "Charleroi");

            migrationBuilder.UpdateData(
                table: "Airports",
                keyColumn: "Id",
                keyValue: 3,
                column: "Location",
                value: "Bruxelles");

            migrationBuilder.UpdateData(
                table: "Airports",
                keyColumn: "Id",
                keyValue: 4,
                column: "Location",
                value: "Ostende");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "Airports");
        }
    }
}
