using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCBookingFinal_YARAB_.Migrations
{
    /// <inheritdoc />
    public partial class draftreservationedit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReservationRooms_DraftReservations_DraftReservationId",
                table: "ReservationRooms");

            migrationBuilder.DropIndex(
                name: "IX_ReservationRooms_DraftReservationId",
                table: "ReservationRooms");

            migrationBuilder.DropColumn(
                name: "DraftReservationId",
                table: "ReservationRooms");

            migrationBuilder.AddColumn<int>(
                name: "DraftReservationId",
                table: "Rooms",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "a2e6bd9c-a054-46c5-8307-9f6fb10d6259");

            migrationBuilder.UpdateData(
                table: "DraftReservations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CheckInDate", "CheckOutDate" },
                values: new object[] { new DateTime(2025, 3, 7, 21, 44, 51, 341, DateTimeKind.Local).AddTicks(2462), new DateTime(2025, 3, 12, 21, 44, 51, 341, DateTimeKind.Local).AddTicks(2471) });

            migrationBuilder.UpdateData(
                table: "PaymentMethod",
                keyColumn: "Id",
                keyValue: 25,
                column: "ExpiryDate",
                value: new DateOnly(2028, 3, 7));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 1,
                column: "PaymentDate",
                value: new DateTime(2025, 3, 7, 21, 44, 51, 342, DateTimeKind.Local).AddTicks(1680));

            migrationBuilder.UpdateData(
                table: "PromoCodes",
                keyColumn: "Id",
                keyValue: 1,
                column: "ExpiryDate",
                value: new DateTime(2025, 3, 12, 21, 44, 51, 342, DateTimeKind.Local).AddTicks(3418));

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: 1,
                column: "ReviewDate",
                value: new DateTime(2025, 3, 7, 21, 44, 51, 342, DateTimeKind.Local).AddTicks(5274));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CheckInDate", "CheckOutDate" },
                values: new object[] { new DateTime(2025, 3, 7, 21, 44, 51, 342, DateTimeKind.Local).AddTicks(7015), new DateTime(2025, 3, 12, 21, 44, 51, 342, DateTimeKind.Local).AddTicks(7020) });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "ReviewDate",
                value: new DateTime(2025, 3, 7, 21, 44, 51, 343, DateTimeKind.Local).AddTicks(543));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1,
                column: "DraftReservationId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_DraftReservationId",
                table: "Rooms",
                column: "DraftReservationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_DraftReservations_DraftReservationId",
                table: "Rooms",
                column: "DraftReservationId",
                principalTable: "DraftReservations",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_DraftReservations_DraftReservationId",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_DraftReservationId",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "DraftReservationId",
                table: "Rooms");

            migrationBuilder.AddColumn<int>(
                name: "DraftReservationId",
                table: "ReservationRooms",
                type: "int",
                nullable: true);

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
                table: "ReservationRooms",
                keyColumn: "id",
                keyValue: 1,
                column: "DraftReservationId",
                value: null);

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

            migrationBuilder.CreateIndex(
                name: "IX_ReservationRooms_DraftReservationId",
                table: "ReservationRooms",
                column: "DraftReservationId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReservationRooms_DraftReservations_DraftReservationId",
                table: "ReservationRooms",
                column: "DraftReservationId",
                principalTable: "DraftReservations",
                principalColumn: "Id");
        }
    }
}
