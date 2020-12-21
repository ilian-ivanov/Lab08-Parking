using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lab08_Parking.Data.Migrations
{
    public partial class addseeddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "DiscountCardId", "EntryTime", "ParkingId", "RegNumber", "Size" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2020, 12, 20, 21, 54, 32, 834, DateTimeKind.Local).AddTicks(211), 1L, "1111", (byte)1 },
                    { 2L, 2L, new DateTime(2020, 12, 20, 17, 54, 32, 836, DateTimeKind.Local).AddTicks(6023), 1L, "1112", (byte)2 },
                    { 3L, 3L, new DateTime(2020, 12, 20, 15, 54, 32, 836, DateTimeKind.Local).AddTicks(6052), 1L, "1113", (byte)4 },
                    { 4L, 1L, new DateTime(2020, 12, 20, 11, 54, 32, 836, DateTimeKind.Local).AddTicks(6056), 1L, "1114", (byte)1 },
                    { 5L, 1L, new DateTime(2020, 12, 20, 7, 54, 32, 836, DateTimeKind.Local).AddTicks(6059), 1L, "1115", (byte)2 },
                    { 6L, 3L, new DateTime(2020, 12, 19, 23, 54, 32, 836, DateTimeKind.Local).AddTicks(6061), 1L, "1116", (byte)4 },
                    { 7L, null, new DateTime(2020, 12, 19, 11, 54, 32, 836, DateTimeKind.Local).AddTicks(6065), 1L, "1117", (byte)1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 7L);
        }
    }
}
