using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JustInTimeCompany.Migrations
{
    public partial class Aircraft_Seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Speed",
                table: "AircraftModels",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.InsertData(
                table: "AircraftModels",
                columns: new[] { "Id", "Name", "PassengerCapacity", "Speed" },
                values: new object[,]
                {
                    { 1, "Eurocopter AS 355 F1/F2 Ecureuil III", 5, 220 },
                    { 2, "Bell 206 JetRanger", 4, 190 },
                    { 3, "Robinson R44 Raven II", 3, 190 }
                });

            migrationBuilder.InsertData(
                table: "Engine",
                columns: new[] { "Id", "Brand", "Model", "Type" },
                values: new object[,]
                {
                    { 1, "Rolls Royce", "250-C20F", "Turbine" },
                    { 2, "Lycoming", "IO-540", "Piston" }
                });

            migrationBuilder.InsertData(
                table: "Aircrafts",
                columns: new[] { "Id", "LastRevision", "ModelId" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 7, 8, 12, 5, 4, 685, DateTimeKind.Local).AddTicks(6877), 1 },
                    { 2, new DateTime(2022, 7, 8, 12, 5, 4, 685, DateTimeKind.Local).AddTicks(6921), 2 },
                    { 3, new DateTime(2022, 7, 8, 12, 5, 4, 685, DateTimeKind.Local).AddTicks(6923), 3 }
                });

            migrationBuilder.InsertData(
                table: "EngineInAircraft",
                columns: new[] { "EngineId", "ModelId", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, 2 },
                    { 1, 2, 1 },
                    { 2, 3, 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Aircrafts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Aircrafts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Aircrafts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "EngineInAircraft",
                keyColumns: new[] { "EngineId", "ModelId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "EngineInAircraft",
                keyColumns: new[] { "EngineId", "ModelId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "EngineInAircraft",
                keyColumns: new[] { "EngineId", "ModelId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "AircraftModels",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AircraftModels",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AircraftModels",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Engine",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Engine",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AlterColumn<double>(
                name: "Speed",
                table: "AircraftModels",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
