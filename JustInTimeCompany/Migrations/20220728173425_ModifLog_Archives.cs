using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JustInTimeCompany.Migrations
{
    public partial class ModifLog_Archives : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FlightArchive_Modifications_AfterLogId",
                table: "FlightArchive");

            migrationBuilder.DropForeignKey(
                name: "FK_FlightArchive_Modifications_BeforeLogId",
                table: "FlightArchive");

            migrationBuilder.DropIndex(
                name: "IX_FlightArchive_AfterLogId",
                table: "FlightArchive");

            migrationBuilder.DropIndex(
                name: "IX_FlightArchive_BeforeLogId",
                table: "FlightArchive");

            migrationBuilder.DropColumn(
                name: "AfterLogId",
                table: "FlightArchive");

            migrationBuilder.DropColumn(
                name: "BeforeLogId",
                table: "FlightArchive");

            migrationBuilder.AddColumn<int>(
                name: "AfterId",
                table: "Modifications",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BeforeId",
                table: "Modifications",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Modifications_AfterId",
                table: "Modifications",
                column: "AfterId");

            migrationBuilder.CreateIndex(
                name: "IX_Modifications_BeforeId",
                table: "Modifications",
                column: "BeforeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Modifications_FlightArchive_AfterId",
                table: "Modifications",
                column: "AfterId",
                principalTable: "FlightArchive",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Modifications_FlightArchive_BeforeId",
                table: "Modifications",
                column: "BeforeId",
                principalTable: "FlightArchive",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Modifications_FlightArchive_AfterId",
                table: "Modifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Modifications_FlightArchive_BeforeId",
                table: "Modifications");

            migrationBuilder.DropIndex(
                name: "IX_Modifications_AfterId",
                table: "Modifications");

            migrationBuilder.DropIndex(
                name: "IX_Modifications_BeforeId",
                table: "Modifications");

            migrationBuilder.DropColumn(
                name: "AfterId",
                table: "Modifications");

            migrationBuilder.DropColumn(
                name: "BeforeId",
                table: "Modifications");

            migrationBuilder.AddColumn<int>(
                name: "AfterLogId",
                table: "FlightArchive",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BeforeLogId",
                table: "FlightArchive",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FlightArchive_AfterLogId",
                table: "FlightArchive",
                column: "AfterLogId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FlightArchive_BeforeLogId",
                table: "FlightArchive",
                column: "BeforeLogId",
                unique: true,
                filter: "[BeforeLogId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_FlightArchive_Modifications_AfterLogId",
                table: "FlightArchive",
                column: "AfterLogId",
                principalTable: "Modifications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FlightArchive_Modifications_BeforeLogId",
                table: "FlightArchive",
                column: "BeforeLogId",
                principalTable: "Modifications",
                principalColumn: "Id");
        }
    }
}
