using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCBookingFinal_YARAB_.Migrations
{
    /// <inheritdoc />
    public partial class yarabarta7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DraftReservationRoom",
                table: "DraftReservationRoom");

            migrationBuilder.AddColumn<int>(
                name: "id",
                table: "DraftReservationRoom",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DraftReservationRoom",
                table: "DraftReservationRoom",
                column: "id");

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

            migrationBuilder.CreateIndex(
                name: "IX_DraftReservationRoom_ReservedId",
                table: "DraftReservationRoom",
                column: "ReservedId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DraftReservationRoom",
                table: "DraftReservationRoom");

            migrationBuilder.DropIndex(
                name: "IX_DraftReservationRoom_ReservedId",
                table: "DraftReservationRoom");

            migrationBuilder.DropColumn(
                name: "id",
                table: "DraftReservationRoom");

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
        }
    }
}
