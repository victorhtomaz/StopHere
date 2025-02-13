using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StopHere.Api.Migrations
{
    /// <inheritdoc />
    public partial class Migration1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR(125)", maxLength: 125, nullable: false),
                    Phone_Number = table.Column<string>(type: "VARCHAR(30)", maxLength: 30, nullable: false),
                    Service_Type = table.Column<short>(type: "SMALLINT", nullable: false),
                    Service_ExpiryDate = table.Column<DateTime>(type: "DATETIME2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ParkingPlace",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Number = table.Column<int>(type: "INT", nullable: false),
                    IsOccupied = table.Column<bool>(type: "BIT", nullable: false),
                    ClientId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkingPlace", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParkingPlace_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Vehicle",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Color = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    Model = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: false),
                    LicensePlate_Value = table.Column<string>(type: "VARCHAR(7)", maxLength: 7, nullable: false),
                    ClientId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicle_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EntryExitRecord",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EntryDate = table.Column<DateTime>(type: "DATETIME2", nullable: false),
                    ExitDate = table.Column<DateTime>(type: "DATETIME2", nullable: true),
                    Duration = table.Column<TimeSpan>(type: "TIME", nullable: true),
                    LicensePlateValue = table.Column<string>(type: "VARCHAR(7)", maxLength: 7, nullable: false),
                    VehicleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ParkingPlaceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntryExitRecord", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EntryExitRecord_ParkingPlace_ParkingPlaceId",
                        column: x => x.ParkingPlaceId,
                        principalTable: "ParkingPlace",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EntryExitRecord_Vehicle_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Client_Phone_Number",
                table: "Client",
                column: "Phone_Number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EntryExitRecord_ParkingPlaceId",
                table: "EntryExitRecord",
                column: "ParkingPlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_EntryExitRecord_VehicleId",
                table: "EntryExitRecord",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_ParkingPlace_ClientId",
                table: "ParkingPlace",
                column: "ClientId",
                unique: true,
                filter: "[ClientId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_ClientId",
                table: "Vehicle",
                column: "ClientId",
                unique: true,
                filter: "[ClientId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EntryExitRecord");

            migrationBuilder.DropTable(
                name: "ParkingPlace");

            migrationBuilder.DropTable(
                name: "Vehicle");

            migrationBuilder.DropTable(
                name: "Client");
        }
    }
}
