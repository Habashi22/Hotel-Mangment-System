using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCBookingFinal_YARAB_.Migrations
{
    /// <inheritdoc />
    public partial class fsf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "status",
                table: "Payments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "RegisterViewModel",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConfirmEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConfirmPassword = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegisterViewModel", x => x.id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "bfdd88cb-8969-409d-bd27-997addcb2532");

            migrationBuilder.UpdateData(
                table: "DraftReservations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CheckInDate", "CheckOutDate" },
                values: new object[] { new DateTime(2025, 3, 3, 2, 42, 36, 130, DateTimeKind.Local).AddTicks(8586), new DateTime(2025, 3, 8, 2, 42, 36, 130, DateTimeKind.Local).AddTicks(8594) });

            migrationBuilder.UpdateData(
                table: "PaymentMethod",
                keyColumn: "Id",
                keyValue: 25,
                column: "ExpiryDate",
                value: new DateOnly(2028, 3, 3));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PaymentDate", "PaymentMethodId", "status" },
                values: new object[] { new DateTime(2025, 3, 3, 2, 42, 36, 131, DateTimeKind.Local).AddTicks(6770), 25, "Confirmed" });

            migrationBuilder.UpdateData(
                table: "PromoCodes",
                keyColumn: "Id",
                keyValue: 1,
                column: "ExpiryDate",
                value: new DateTime(2025, 3, 8, 2, 42, 36, 131, DateTimeKind.Local).AddTicks(8502));

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: 1,
                column: "ReviewDate",
                value: new DateTime(2025, 3, 3, 2, 42, 36, 132, DateTimeKind.Local).AddTicks(291));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CheckInDate", "CheckOutDate" },
                values: new object[] { new DateTime(2025, 3, 3, 2, 42, 36, 132, DateTimeKind.Local).AddTicks(2062), new DateTime(2025, 3, 8, 2, 42, 36, 132, DateTimeKind.Local).AddTicks(2066) });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "ReviewDate",
                value: new DateTime(2025, 3, 3, 2, 42, 36, 132, DateTimeKind.Local).AddTicks(5493));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RegisterViewModel");

            migrationBuilder.DropColumn(
                name: "status",
                table: "Payments");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "bc90d424-7439-4e3e-9ede-0131df874dfc");

            migrationBuilder.UpdateData(
                table: "DraftReservations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CheckInDate", "CheckOutDate" },
                values: new object[] { new DateTime(2025, 3, 2, 3, 6, 4, 951, DateTimeKind.Local).AddTicks(2925), new DateTime(2025, 3, 7, 3, 6, 4, 951, DateTimeKind.Local).AddTicks(2932) });

            migrationBuilder.UpdateData(
                table: "PaymentMethod",
                keyColumn: "Id",
                keyValue: 25,
                column: "ExpiryDate",
                value: new DateOnly(2028, 3, 2));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PaymentDate", "PaymentMethodId" },
                values: new object[] { new DateTime(2025, 3, 2, 3, 6, 4, 952, DateTimeKind.Local).AddTicks(1859), 1 });

            migrationBuilder.UpdateData(
                table: "PromoCodes",
                keyColumn: "Id",
                keyValue: 1,
                column: "ExpiryDate",
                value: new DateTime(2025, 3, 7, 3, 6, 4, 952, DateTimeKind.Local).AddTicks(3573));

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: 1,
                column: "ReviewDate",
                value: new DateTime(2025, 3, 2, 3, 6, 4, 952, DateTimeKind.Local).AddTicks(5248));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CheckInDate", "CheckOutDate" },
                values: new object[] { new DateTime(2025, 3, 2, 3, 6, 4, 952, DateTimeKind.Local).AddTicks(7050), new DateTime(2025, 3, 7, 3, 6, 4, 952, DateTimeKind.Local).AddTicks(7055) });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "ReviewDate",
                value: new DateTime(2025, 3, 2, 3, 6, 4, 953, DateTimeKind.Local).AddTicks(518));
        }
    }
}
