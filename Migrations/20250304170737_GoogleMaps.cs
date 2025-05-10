using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCBookingFinal_YARAB_.Migrations
{
    /// <inheritdoc />
    public partial class GoogleMaps : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Latitude",
                table: "Hotels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Longitude",
                table: "Hotels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "5cd4d423-2e79-4caa-8175-074c2732c788");

            migrationBuilder.UpdateData(
                table: "DraftReservations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CheckInDate", "CheckOutDate" },
                values: new object[] { new DateTime(2025, 3, 4, 19, 7, 35, 223, DateTimeKind.Local).AddTicks(5280), new DateTime(2025, 3, 9, 19, 7, 35, 223, DateTimeKind.Local).AddTicks(5287) });

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "Latitude", "Longitude" },
                values: new object[] { "0", "0" });

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 1,
                column: "PaymentDate",
                value: new DateTime(2025, 3, 4, 19, 7, 35, 224, DateTimeKind.Local).AddTicks(3480));

            migrationBuilder.UpdateData(
                table: "PromoCodes",
                keyColumn: "Id",
                keyValue: 1,
                column: "ExpiryDate",
                value: new DateTime(2025, 3, 9, 19, 7, 35, 224, DateTimeKind.Local).AddTicks(5207));

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: 1,
                column: "ReviewDate",
                value: new DateTime(2025, 3, 4, 19, 7, 35, 224, DateTimeKind.Local).AddTicks(6950));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CheckInDate", "CheckOutDate" },
                values: new object[] { new DateTime(2025, 3, 4, 19, 7, 35, 224, DateTimeKind.Local).AddTicks(8749), new DateTime(2025, 3, 9, 19, 7, 35, 224, DateTimeKind.Local).AddTicks(8753) });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "ReviewDate",
                value: new DateTime(2025, 3, 4, 19, 7, 35, 225, DateTimeKind.Local).AddTicks(2207));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Hotels");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "8d2b31f3-1dc1-40aa-9a0e-a6130f62dd21");

            migrationBuilder.UpdateData(
                table: "DraftReservations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CheckInDate", "CheckOutDate" },
                values: new object[] { new DateTime(2025, 3, 4, 6, 55, 27, 440, DateTimeKind.Local).AddTicks(5519), new DateTime(2025, 3, 9, 6, 55, 27, 440, DateTimeKind.Local).AddTicks(5524) });

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 1,
                column: "PaymentDate",
                value: new DateTime(2025, 3, 4, 6, 55, 27, 441, DateTimeKind.Local).AddTicks(3289));

            migrationBuilder.UpdateData(
                table: "PromoCodes",
                keyColumn: "Id",
                keyValue: 1,
                column: "ExpiryDate",
                value: new DateTime(2025, 3, 9, 6, 55, 27, 441, DateTimeKind.Local).AddTicks(4833));

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: 1,
                column: "ReviewDate",
                value: new DateTime(2025, 3, 4, 6, 55, 27, 441, DateTimeKind.Local).AddTicks(6532));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CheckInDate", "CheckOutDate" },
                values: new object[] { new DateTime(2025, 3, 4, 6, 55, 27, 441, DateTimeKind.Local).AddTicks(8196), new DateTime(2025, 3, 9, 6, 55, 27, 441, DateTimeKind.Local).AddTicks(8201) });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "ReviewDate",
                value: new DateTime(2025, 3, 4, 6, 55, 27, 442, DateTimeKind.Local).AddTicks(1454));
        }
    }
}
