using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StopHere.Api.Migrations
{
    /// <inheritdoc />
    public partial class Migration3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParkingPlace_Client_ClientId",
                table: "ParkingPlace");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_Client_ClientId",
                table: "Vehicle");

            migrationBuilder.CreateIndex(
                name: "IX_ParkingPlace_Number",
                table: "ParkingPlace",
                column: "Number",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ParkingPlace_Client_ClientId",
                table: "ParkingPlace",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_Client_ClientId",
                table: "Vehicle",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParkingPlace_Client_ClientId",
                table: "ParkingPlace");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_Client_ClientId",
                table: "Vehicle");

            migrationBuilder.DropIndex(
                name: "IX_ParkingPlace_Number",
                table: "ParkingPlace");

            migrationBuilder.AddForeignKey(
                name: "FK_ParkingPlace_Client_ClientId",
                table: "ParkingPlace",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_Client_ClientId",
                table: "Vehicle",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "Id");
        }
    }
}
