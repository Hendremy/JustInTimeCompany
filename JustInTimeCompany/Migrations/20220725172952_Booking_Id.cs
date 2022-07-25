using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JustInTimeCompany.Migrations
{
    public partial class Booking_Id : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Bookings",
                table: "Bookings");

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumns: new[] { "CustomerId", "FlightId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumns: new[] { "CustomerId", "FlightId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumns: new[] { "CustomerId", "FlightId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumns: new[] { "CustomerId", "FlightId" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumns: new[] { "CustomerId", "FlightId" },
                keyValues: new object[] { 3, 5 });

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bookings",
                table: "Bookings",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "CustomerId", "FlightId", "SeatsTaken" },
                values: new object[,]
                {
                    { 1, 1, 1, 1 },
                    { 2, 1, 2, 1 },
                    { 3, 2, 3, 1 },
                    { 4, 1, 4, 1 },
                    { 5, 3, 5, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_FlightId",
                table: "Bookings",
                column: "FlightId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Bookings",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_FlightId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Bookings");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bookings",
                table: "Bookings",
                columns: new[] { "FlightId", "CustomerId" });
        }
    }
}
