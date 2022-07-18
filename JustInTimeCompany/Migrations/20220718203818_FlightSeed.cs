using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JustInTimeCompany.Migrations
{
    public partial class FlightSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Paths",
                columns: new[] { "Id", "FromId", "ToId" },
                values: new object[,]
                {
                    { 1, 1, 4 },
                    { 2, 4, 1 },
                    { 3, 3, 1 }
                });

            migrationBuilder.InsertData(
                table: "Schedule",
                columns: new[] { "Id", "Landing", "TakeOff" },
                values: new object[,]
                {
                    { 1, new DateTime(22, 10, 5, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(22, 10, 5, 15, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(22, 9, 15, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(22, 9, 15, 12, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(22, 9, 20, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(22, 9, 20, 14, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(22, 7, 15, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(22, 7, 15, 9, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(22, 7, 18, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(22, 7, 18, 20, 30, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "Id", "AircraftId", "PathId", "PilotId", "ScheduleId" },
                values: new object[,]
                {
                    { 1, 1, 1, 1, 1 },
                    { 2, 1, 1, 3, 2 },
                    { 3, 2, 2, 3, 3 },
                    { 4, 3, 3, 2, 4 },
                    { 5, 3, 3, 2, 5 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Paths",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Paths",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Paths",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Schedule",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Schedule",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Schedule",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Schedule",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Schedule",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
