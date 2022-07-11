using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JustInTimeCompany.Migrations
{
    public partial class Aircraft_LastRevisionRenamed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastRevision",
                table: "Aircrafts",
                newName: "LastCheckUpDate");

            migrationBuilder.UpdateData(
                table: "Aircrafts",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastCheckUpDate",
                value: new DateTime(11, 7, 22, 15, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Aircrafts",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastCheckUpDate",
                value: new DateTime(11, 7, 22, 15, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Aircrafts",
                keyColumn: "Id",
                keyValue: 3,
                column: "LastCheckUpDate",
                value: new DateTime(11, 7, 22, 15, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastCheckUpDate",
                table: "Aircrafts",
                newName: "LastRevision");

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
        }
    }
}
