using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCBookingFinal_YARAB_.Migrations
{
    /// <inheritdoc />
    public partial class firstبش : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Capacity",
                table: "Rooms");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "6b7c42dc-d2fd-4798-bd78-2e3dfa52b01c");

            migrationBuilder.UpdateData(
                table: "DraftReservations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CheckInDate", "CheckOutDate" },
                values: new object[] { new DateTime(2025, 3, 5, 20, 47, 6, 937, DateTimeKind.Local).AddTicks(2078), new DateTime(2025, 3, 10, 20, 47, 6, 937, DateTimeKind.Local).AddTicks(2086) });

            migrationBuilder.UpdateData(
                table: "PaymentMethod",
                keyColumn: "Id",
                keyValue: 25,
                column: "ExpiryDate",
                value: new DateOnly(2028, 3, 5));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 1,
                column: "PaymentDate",
                value: new DateTime(2025, 3, 5, 20, 47, 6, 938, DateTimeKind.Local).AddTicks(2262));

            migrationBuilder.UpdateData(
                table: "PromoCodes",
                keyColumn: "Id",
                keyValue: 1,
                column: "ExpiryDate",
                value: new DateTime(2025, 3, 10, 20, 47, 6, 938, DateTimeKind.Local).AddTicks(4463));

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: 1,
                column: "ReviewDate",
                value: new DateTime(2025, 3, 5, 20, 47, 6, 938, DateTimeKind.Local).AddTicks(6610));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CheckInDate", "CheckOutDate" },
                values: new object[] { new DateTime(2025, 3, 5, 20, 47, 6, 938, DateTimeKind.Local).AddTicks(8565), new DateTime(2025, 3, 10, 20, 47, 6, 938, DateTimeKind.Local).AddTicks(8570) });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "ReviewDate",
                value: new DateTime(2025, 3, 5, 20, 47, 6, 939, DateTimeKind.Local).AddTicks(2234));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Capacity",
                table: "Rooms",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
                table: "PaymentMethod",
                keyColumn: "Id",
                keyValue: 25,
                column: "ExpiryDate",
                value: new DateOnly(2028, 3, 4));

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

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1,
                column: "Capacity",
                value: 5);
        }
    }
}
