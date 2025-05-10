using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCBookingFinal_YARAB_.Migrations
{
    /// <inheritdoc />
    public partial class asjkldfhasjkdh : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DraftReservations_UsedPromoCodes_UsedPromoCodeId",
                table: "DraftReservations");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "7620c9eb-158f-4338-a8af-e6c52626f403");

            migrationBuilder.UpdateData(
                table: "DraftReservations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CheckInDate", "CheckOutDate" },
                values: new object[] { new DateTime(2025, 3, 8, 2, 28, 31, 443, DateTimeKind.Local).AddTicks(2125), new DateTime(2025, 3, 13, 2, 28, 31, 443, DateTimeKind.Local).AddTicks(2133) });

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 1,
                column: "PaymentDate",
                value: new DateTime(2025, 3, 8, 2, 28, 31, 444, DateTimeKind.Local).AddTicks(861));

            migrationBuilder.UpdateData(
                table: "PromoCodes",
                keyColumn: "Id",
                keyValue: 1,
                column: "ExpiryDate",
                value: new DateTime(2025, 3, 13, 2, 28, 31, 444, DateTimeKind.Local).AddTicks(2605));

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: 1,
                column: "ReviewDate",
                value: new DateTime(2025, 3, 8, 2, 28, 31, 444, DateTimeKind.Local).AddTicks(4338));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CheckInDate", "CheckOutDate" },
                values: new object[] { new DateTime(2025, 3, 8, 2, 28, 31, 444, DateTimeKind.Local).AddTicks(6213), new DateTime(2025, 3, 13, 2, 28, 31, 444, DateTimeKind.Local).AddTicks(6217) });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "ReviewDate",
                value: new DateTime(2025, 3, 8, 2, 28, 31, 444, DateTimeKind.Local).AddTicks(9776));

            migrationBuilder.AddForeignKey(
                name: "FK_DraftReservations_PromoCodes_UsedPromoCodeId",
                table: "DraftReservations",
                column: "UsedPromoCodeId",
                principalTable: "PromoCodes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DraftReservations_PromoCodes_UsedPromoCodeId",
                table: "DraftReservations");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "1119c45a-9a2f-4206-a38a-29608c0a0fdf");

            migrationBuilder.UpdateData(
                table: "DraftReservations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CheckInDate", "CheckOutDate" },
                values: new object[] { new DateTime(2025, 3, 8, 1, 47, 9, 714, DateTimeKind.Local).AddTicks(1652), new DateTime(2025, 3, 13, 1, 47, 9, 714, DateTimeKind.Local).AddTicks(1668) });

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 1,
                column: "PaymentDate",
                value: new DateTime(2025, 3, 8, 1, 47, 9, 715, DateTimeKind.Local).AddTicks(1088));

            migrationBuilder.UpdateData(
                table: "PromoCodes",
                keyColumn: "Id",
                keyValue: 1,
                column: "ExpiryDate",
                value: new DateTime(2025, 3, 13, 1, 47, 9, 715, DateTimeKind.Local).AddTicks(2790));

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: 1,
                column: "ReviewDate",
                value: new DateTime(2025, 3, 8, 1, 47, 9, 715, DateTimeKind.Local).AddTicks(4518));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CheckInDate", "CheckOutDate" },
                values: new object[] { new DateTime(2025, 3, 8, 1, 47, 9, 715, DateTimeKind.Local).AddTicks(6244), new DateTime(2025, 3, 13, 1, 47, 9, 715, DateTimeKind.Local).AddTicks(6248) });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "ReviewDate",
                value: new DateTime(2025, 3, 8, 1, 47, 9, 715, DateTimeKind.Local).AddTicks(9655));

            migrationBuilder.AddForeignKey(
                name: "FK_DraftReservations_UsedPromoCodes_UsedPromoCodeId",
                table: "DraftReservations",
                column: "UsedPromoCodeId",
                principalTable: "UsedPromoCodes",
                principalColumn: "Id");
        }
    }
}
