using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lab08_Parking.Data.Migrations
{
    public partial class AddSeedMethod : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DailyRateStartTime",
                table: "Parkings");

            migrationBuilder.DropColumn(
                name: "DailyRateStopTime",
                table: "Parkings");

            migrationBuilder.AddColumn<byte>(
                name: "DailyRateStartHour",
                table: "Parkings",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "DailyRateStopHour",
                table: "Parkings",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.InsertData(
                table: "Parkings",
                columns: new[] { "Id", "DailyRate", "DailyRateStartHour", "DailyRateStopHour", "NightlyRate", "Size" },
                values: new object[] { 1L, 3m, (byte)8, (byte)18, 2m, (byte)200 });

            migrationBuilder.InsertData(
                table: "DiscountCards",
                columns: new[] { "Id", "Discount", "Name", "ParkingId" },
                values: new object[] { 1L, (byte)10, "Silver", 1L });

            migrationBuilder.InsertData(
                table: "DiscountCards",
                columns: new[] { "Id", "Discount", "Name", "ParkingId" },
                values: new object[] { 2L, (byte)15, "Gold", 1L });

            migrationBuilder.InsertData(
                table: "DiscountCards",
                columns: new[] { "Id", "Discount", "Name", "ParkingId" },
                values: new object[] { 3L, (byte)20, "Platinum", 1L });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DiscountCards",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "DiscountCards",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "DiscountCards",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Parkings",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DropColumn(
                name: "DailyRateStartHour",
                table: "Parkings");

            migrationBuilder.DropColumn(
                name: "DailyRateStopHour",
                table: "Parkings");

            migrationBuilder.AddColumn<DateTime>(
                name: "DailyRateStartTime",
                table: "Parkings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DailyRateStopTime",
                table: "Parkings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
