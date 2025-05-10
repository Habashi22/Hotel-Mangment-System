using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCBookingFinal_YARAB_.Migrations
{
    /// <inheritdoc />
    public partial class last : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "DraftReservationRoom",
                columns: table => new
                {
                    DraftReservationsId = table.Column<int>(type: "int", nullable: false),
                    ReservedId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DraftReservationRoom", x => new { x.DraftReservationsId, x.ReservedId });
                    table.ForeignKey(
                        name: "FK_DraftReservationRoom_DraftReservations_DraftReservationsId",
                        column: x => x.DraftReservationsId,
                        principalTable: "DraftReservations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DraftReservationRoom_Rooms_ReservedId",
                        column: x => x.ReservedId,
                        principalTable: "Rooms",
                        principalColumn: "Id");
                });

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DraftReservationRoom");

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
                value: "1df116c7-7398-4c18-8139-42623085e053");

            migrationBuilder.UpdateData(
                table: "DraftReservations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CheckInDate", "CheckOutDate" },
                values: new object[] { new DateTime(2025, 3, 7, 22, 10, 33, 610, DateTimeKind.Local).AddTicks(2444), new DateTime(2025, 3, 12, 22, 10, 33, 610, DateTimeKind.Local).AddTicks(2451) });

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 1,
                column: "PaymentDate",
                value: new DateTime(2025, 3, 7, 22, 10, 33, 611, DateTimeKind.Local).AddTicks(851));

            migrationBuilder.UpdateData(
                table: "PromoCodes",
                keyColumn: "Id",
                keyValue: 1,
                column: "ExpiryDate",
                value: new DateTime(2025, 3, 12, 22, 10, 33, 611, DateTimeKind.Local).AddTicks(2626));

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: 1,
                column: "ReviewDate",
                value: new DateTime(2025, 3, 7, 22, 10, 33, 611, DateTimeKind.Local).AddTicks(4363));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CheckInDate", "CheckOutDate" },
                values: new object[] { new DateTime(2025, 3, 7, 22, 10, 33, 611, DateTimeKind.Local).AddTicks(6095), new DateTime(2025, 3, 12, 22, 10, 33, 611, DateTimeKind.Local).AddTicks(6099) });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "ReviewDate",
                value: new DateTime(2025, 3, 7, 22, 10, 33, 611, DateTimeKind.Local).AddTicks(9501));

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
    }
}
