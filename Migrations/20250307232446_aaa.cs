using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCBookingFinal_YARAB_.Migrations
{
    /// <inheritdoc />
    public partial class aaa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DraftReservationRoom_DraftReservations_DraftReservationsId",
                table: "DraftReservationRoom");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DraftReservationRoom",
                table: "DraftReservationRoom");

            migrationBuilder.DropIndex(
                name: "IX_DraftReservationRoom_ReservedId",
                table: "DraftReservationRoom");

            migrationBuilder.RenameColumn(
                name: "DraftReservationsId",
                table: "DraftReservationRoom",
                newName: "DraftReservationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DraftReservationRoom",
                table: "DraftReservationRoom",
                columns: new[] { "ReservedId", "DraftReservationId" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "d80957ee-b171-449f-8025-1f172853bc1c");

            migrationBuilder.UpdateData(
                table: "DraftReservations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CheckInDate", "CheckOutDate" },
                values: new object[] { new DateTime(2025, 3, 8, 1, 24, 45, 272, DateTimeKind.Local).AddTicks(92), new DateTime(2025, 3, 13, 1, 24, 45, 272, DateTimeKind.Local).AddTicks(103) });

            migrationBuilder.UpdateData(
                table: "PaymentMethod",
                keyColumn: "Id",
                keyValue: 25,
                column: "ExpiryDate",
                value: new DateOnly(2028, 3, 8));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 1,
                column: "PaymentDate",
                value: new DateTime(2025, 3, 8, 1, 24, 45, 274, DateTimeKind.Local).AddTicks(2775));

            migrationBuilder.UpdateData(
                table: "PromoCodes",
                keyColumn: "Id",
                keyValue: 1,
                column: "ExpiryDate",
                value: new DateTime(2025, 3, 13, 1, 24, 45, 274, DateTimeKind.Local).AddTicks(4840));

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: 1,
                column: "ReviewDate",
                value: new DateTime(2025, 3, 8, 1, 24, 45, 274, DateTimeKind.Local).AddTicks(6732));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CheckInDate", "CheckOutDate" },
                values: new object[] { new DateTime(2025, 3, 8, 1, 24, 45, 274, DateTimeKind.Local).AddTicks(8607), new DateTime(2025, 3, 13, 1, 24, 45, 274, DateTimeKind.Local).AddTicks(8611) });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "ReviewDate",
                value: new DateTime(2025, 3, 8, 1, 24, 45, 275, DateTimeKind.Local).AddTicks(2480));

            migrationBuilder.CreateIndex(
                name: "IX_DraftReservationRoom_DraftReservationId",
                table: "DraftReservationRoom",
                column: "DraftReservationId");

            migrationBuilder.AddForeignKey(
                name: "FK_DraftReservationRoom_DraftReservations_DraftReservationId",
                table: "DraftReservationRoom",
                column: "DraftReservationId",
                principalTable: "DraftReservations",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DraftReservationRoom_DraftReservations_DraftReservationId",
                table: "DraftReservationRoom");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DraftReservationRoom",
                table: "DraftReservationRoom");

            migrationBuilder.DropIndex(
                name: "IX_DraftReservationRoom_DraftReservationId",
                table: "DraftReservationRoom");

            migrationBuilder.RenameColumn(
                name: "DraftReservationId",
                table: "DraftReservationRoom",
                newName: "DraftReservationsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DraftReservationRoom",
                table: "DraftReservationRoom",
                columns: new[] { "DraftReservationsId", "ReservedId" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "c0755c82-43c0-421e-93ee-8a314568014c");

            migrationBuilder.UpdateData(
                table: "DraftReservations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CheckInDate", "CheckOutDate" },
                values: new object[] { new DateTime(2025, 3, 7, 22, 18, 11, 175, DateTimeKind.Local).AddTicks(4274), new DateTime(2025, 3, 12, 22, 18, 11, 175, DateTimeKind.Local).AddTicks(4289) });

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
                value: new DateTime(2025, 3, 7, 22, 18, 11, 176, DateTimeKind.Local).AddTicks(4778));

            migrationBuilder.UpdateData(
                table: "PromoCodes",
                keyColumn: "Id",
                keyValue: 1,
                column: "ExpiryDate",
                value: new DateTime(2025, 3, 12, 22, 18, 11, 176, DateTimeKind.Local).AddTicks(6823));

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: 1,
                column: "ReviewDate",
                value: new DateTime(2025, 3, 7, 22, 18, 11, 176, DateTimeKind.Local).AddTicks(8855));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CheckInDate", "CheckOutDate" },
                values: new object[] { new DateTime(2025, 3, 7, 22, 18, 11, 177, DateTimeKind.Local).AddTicks(1358), new DateTime(2025, 3, 12, 22, 18, 11, 177, DateTimeKind.Local).AddTicks(1363) });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "ReviewDate",
                value: new DateTime(2025, 3, 7, 22, 18, 11, 177, DateTimeKind.Local).AddTicks(5692));

            migrationBuilder.CreateIndex(
                name: "IX_DraftReservationRoom_ReservedId",
                table: "DraftReservationRoom",
                column: "ReservedId");

            migrationBuilder.AddForeignKey(
                name: "FK_DraftReservationRoom_DraftReservations_DraftReservationsId",
                table: "DraftReservationRoom",
                column: "DraftReservationsId",
                principalTable: "DraftReservations",
                principalColumn: "Id");
        }
    }
}
