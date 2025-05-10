using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCBookingFinal_YARAB_.Migrations
{
    /// <inheritdoc />
    public partial class lastt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DraftReservations_Amenities_AmenityId",
                table: "DraftReservations");

            migrationBuilder.DropForeignKey(
                name: "FK_DraftReservations_MealPlans_mealPlanId",
                table: "DraftReservations");

            migrationBuilder.DropIndex(
                name: "IX_DraftReservations_AmenityId",
                table: "DraftReservations");

            migrationBuilder.DropIndex(
                name: "IX_DraftReservations_mealPlanId",
                table: "DraftReservations");

            migrationBuilder.RenameColumn(
                name: "mealPlanId",
                table: "DraftReservations",
                newName: "mealPlan");

            migrationBuilder.RenameColumn(
                name: "AmenityId",
                table: "DraftReservations",
                newName: "amenity");

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
                columns: new[] { "CheckInDate", "CheckOutDate", "amenity", "mealPlan" },
                values: new object[] { new DateTime(2025, 3, 7, 22, 10, 33, 610, DateTimeKind.Local).AddTicks(2444), new DateTime(2025, 3, 12, 22, 10, 33, 610, DateTimeKind.Local).AddTicks(2451), null, null });

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "mealPlan",
                table: "DraftReservations",
                newName: "mealPlanId");

            migrationBuilder.RenameColumn(
                name: "amenity",
                table: "DraftReservations",
                newName: "AmenityId");

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
                columns: new[] { "AmenityId", "CheckInDate", "CheckOutDate", "mealPlanId" },
                values: new object[] { 1, new DateTime(2025, 3, 7, 21, 44, 51, 341, DateTimeKind.Local).AddTicks(2462), new DateTime(2025, 3, 12, 21, 44, 51, 341, DateTimeKind.Local).AddTicks(2471), 1 });

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

            migrationBuilder.CreateIndex(
                name: "IX_DraftReservations_AmenityId",
                table: "DraftReservations",
                column: "AmenityId");

            migrationBuilder.CreateIndex(
                name: "IX_DraftReservations_mealPlanId",
                table: "DraftReservations",
                column: "mealPlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_DraftReservations_Amenities_AmenityId",
                table: "DraftReservations",
                column: "AmenityId",
                principalTable: "Amenities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DraftReservations_MealPlans_mealPlanId",
                table: "DraftReservations",
                column: "mealPlanId",
                principalTable: "MealPlans",
                principalColumn: "Id");
        }
    }
}
