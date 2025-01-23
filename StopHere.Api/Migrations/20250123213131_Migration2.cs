using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StopHere.Api.Migrations
{
    /// <inheritdoc />
    public partial class Migration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_LicensePlate_Value",
                table: "Vehicle",
                column: "LicensePlate_Value",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Vehicle_LicensePlate_Value",
                table: "Vehicle");
        }
    }
}
