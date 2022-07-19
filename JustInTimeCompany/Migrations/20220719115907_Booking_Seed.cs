using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JustInTimeCompany.Migrations
{
    public partial class Booking_Seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "CustomerId", "FlightId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 3 },
                    { 1, 4 },
                    { 3, 5 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
