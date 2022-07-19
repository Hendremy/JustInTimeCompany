using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JustInTimeCompany.Migrations
{
    public partial class Schedule_Date_Fixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Schedule",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Landing", "TakeOff" },
                values: new object[] { new DateTime(2022, 10, 5, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 10, 5, 15, 30, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Schedule",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Landing", "TakeOff" },
                values: new object[] { new DateTime(2022, 9, 15, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 15, 12, 30, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Schedule",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Landing", "TakeOff" },
                values: new object[] { new DateTime(2022, 9, 20, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 20, 14, 30, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Schedule",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Landing", "TakeOff" },
                values: new object[] { new DateTime(2022, 7, 15, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 7, 15, 9, 30, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Schedule",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Landing", "TakeOff" },
                values: new object[] { new DateTime(2022, 7, 18, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 7, 18, 20, 30, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Schedule",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Landing", "TakeOff" },
                values: new object[] { new DateTime(22, 10, 5, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(22, 10, 5, 15, 30, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Schedule",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Landing", "TakeOff" },
                values: new object[] { new DateTime(22, 9, 15, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(22, 9, 15, 12, 30, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Schedule",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Landing", "TakeOff" },
                values: new object[] { new DateTime(22, 9, 20, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(22, 9, 20, 14, 30, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Schedule",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Landing", "TakeOff" },
                values: new object[] { new DateTime(22, 7, 15, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(22, 7, 15, 9, 30, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Schedule",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Landing", "TakeOff" },
                values: new object[] { new DateTime(22, 7, 18, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(22, 7, 18, 20, 30, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
