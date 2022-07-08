using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JustInTimeCompany.Migrations
{
    public partial class Airport_Seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Aircrafts",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastRevision",
                value: new DateTime(2022, 7, 8, 12, 51, 14, 603, DateTimeKind.Local).AddTicks(9208));

            migrationBuilder.UpdateData(
                table: "Aircrafts",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastRevision",
                value: new DateTime(2022, 7, 8, 12, 51, 14, 603, DateTimeKind.Local).AddTicks(9258));

            migrationBuilder.UpdateData(
                table: "Aircrafts",
                keyColumn: "Id",
                keyValue: 3,
                column: "LastRevision",
                value: new DateTime(2022, 7, 8, 12, 51, 14, 603, DateTimeKind.Local).AddTicks(9260));

            migrationBuilder.InsertData(
                table: "Airports",
                columns: new[] { "Id", "Latitude", "Longitude", "Name" },
                values: new object[,]
                {
                    { 1, 50.63583079, 5.4393315759999998, "Aéroport de Liège" },
                    { 2, 50.455998176000001, 4.4516648600000002, "Aéroport de Charleroi Bruxelles-Sud" },
                    { 3, 50.900829729999998, 4.4839980639999997, "Aéroport de Bruxelles-National" },
                    { 4, 51.193165894000003, 2.8581632340000001, "Aéroport d'Ostende-Bruges" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Airports",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Airports",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Airports",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Airports",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "Aircrafts",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastRevision",
                value: new DateTime(2022, 7, 8, 12, 5, 4, 685, DateTimeKind.Local).AddTicks(6877));

            migrationBuilder.UpdateData(
                table: "Aircrafts",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastRevision",
                value: new DateTime(2022, 7, 8, 12, 5, 4, 685, DateTimeKind.Local).AddTicks(6921));

            migrationBuilder.UpdateData(
                table: "Aircrafts",
                keyColumn: "Id",
                keyValue: 3,
                column: "LastRevision",
                value: new DateTime(2022, 7, 8, 12, 5, 4, 685, DateTimeKind.Local).AddTicks(6923));
        }
    }
}
