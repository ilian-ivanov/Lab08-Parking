using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lab08_Parking.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Parkings",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Size = table.Column<byte>(type: "tinyint", nullable: false),
                    DailyRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NightlyRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DailyRateStartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DailyRateStopTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parkings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DiscountCards",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discount = table.Column<byte>(type: "tinyint", nullable: false),
                    ParkingId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscountCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DiscountCards_Parkings_ParkingId",
                        column: x => x.ParkingId,
                        principalTable: "Parkings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Size = table.Column<byte>(type: "tinyint", nullable: false),
                    DiscountCardId = table.Column<long>(type: "bigint", nullable: true),
                    ParkingId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicles_DiscountCards_DiscountCardId",
                        column: x => x.DiscountCardId,
                        principalTable: "DiscountCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vehicles_Parkings_ParkingId",
                        column: x => x.ParkingId,
                        principalTable: "Parkings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DiscountCards_ParkingId",
                table: "DiscountCards",
                column: "ParkingId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_DiscountCardId",
                table: "Vehicles",
                column: "DiscountCardId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_ParkingId",
                table: "Vehicles",
                column: "ParkingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "DiscountCards");

            migrationBuilder.DropTable(
                name: "Parkings");
        }
    }
}
