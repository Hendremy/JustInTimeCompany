using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JustInTimeCompany.Migrations
{
    public partial class Booking_Number_OF_Seats : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SeatsTaken",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumns: new[] { "CustomerId", "FlightId" },
                keyValues: new object[] { 1, 1 },
                column: "SeatsTaken",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumns: new[] { "CustomerId", "FlightId" },
                keyValues: new object[] { 1, 2 },
                column: "SeatsTaken",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumns: new[] { "CustomerId", "FlightId" },
                keyValues: new object[] { 2, 3 },
                column: "SeatsTaken",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumns: new[] { "CustomerId", "FlightId" },
                keyValues: new object[] { 1, 4 },
                column: "SeatsTaken",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumns: new[] { "CustomerId", "FlightId" },
                keyValues: new object[] { 3, 5 },
                column: "SeatsTaken",
                value: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SeatsTaken",
                table: "Bookings");
        }
    }
}
