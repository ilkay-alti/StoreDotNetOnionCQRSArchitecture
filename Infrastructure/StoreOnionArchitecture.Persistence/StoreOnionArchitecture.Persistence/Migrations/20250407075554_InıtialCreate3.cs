using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreOnionArchitecture.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InıtialCreate3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2025, 4, 7, 0, 55, 53, 759, DateTimeKind.Local).AddTicks(2723), "Games & Books" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2025, 4, 7, 0, 55, 53, 761, DateTimeKind.Local).AddTicks(6946), "Grocery & Jewelery" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2025, 4, 7, 0, 55, 53, 761, DateTimeKind.Local).AddTicks(6981), "Electronics" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 4, 7, 0, 55, 53, 762, DateTimeKind.Local).AddTicks(7222));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 4, 7, 0, 55, 53, 762, DateTimeKind.Local).AddTicks(7237));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 4, 7, 0, 55, 53, 762, DateTimeKind.Local).AddTicks(7241));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2025, 4, 7, 0, 55, 53, 762, DateTimeKind.Local).AddTicks(7243));

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Description", "Title" },
                values: new object[] { new DateTime(2025, 4, 7, 0, 55, 53, 779, DateTimeKind.Local).AddTicks(6976), "Koşuyorlar eius et ipsa voluptatem.", "İncidunt." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Description", "Title" },
                values: new object[] { new DateTime(2025, 4, 7, 0, 55, 53, 779, DateTimeKind.Local).AddTicks(7079), "Qui enim öyle nisi ve.", "Adipisci nemo." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Description", "Title" },
                values: new object[] { new DateTime(2025, 4, 7, 0, 55, 53, 779, DateTimeKind.Local).AddTicks(7111), "Aut açılmadan explicabo nemo sıla.", "Ex." });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2025, 4, 7, 0, 55, 53, 782, DateTimeKind.Local).AddTicks(5743), "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", 5.25620386675370m, 622.16m, "Awesome Wooden Gloves" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2025, 4, 7, 0, 55, 53, 782, DateTimeKind.Local).AddTicks(5849), "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", 5.286858765496780m, 452.77m, "Rustic Fresh Computer" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2025, 4, 7, 0, 54, 15, 6, DateTimeKind.Local).AddTicks(7917), "Music" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2025, 4, 7, 0, 54, 15, 9, DateTimeKind.Local).AddTicks(5834), "Shoes & Automotive" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2025, 4, 7, 0, 54, 15, 9, DateTimeKind.Local).AddTicks(6058), "Garden, Music & Beauty" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 4, 7, 0, 54, 15, 13, DateTimeKind.Local).AddTicks(7401));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 4, 7, 0, 54, 15, 13, DateTimeKind.Local).AddTicks(7417));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 4, 7, 0, 54, 15, 13, DateTimeKind.Local).AddTicks(7420));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2025, 4, 7, 0, 54, 15, 13, DateTimeKind.Local).AddTicks(7423));

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Description", "Title" },
                values: new object[] { new DateTime(2025, 4, 7, 0, 54, 15, 30, DateTimeKind.Local).AddTicks(8522), "Mi aspernatur eos ad nesciunt.", "Eum." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Description", "Title" },
                values: new object[] { new DateTime(2025, 4, 7, 0, 54, 15, 30, DateTimeKind.Local).AddTicks(8645), "Molestiae aspernatur accusantium nemo gitti.", "Ut numquam." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Description", "Title" },
                values: new object[] { new DateTime(2025, 4, 7, 0, 54, 15, 30, DateTimeKind.Local).AddTicks(8680), "Numquam doloremque dağılımı iure layıkıyla.", "Exercitationem." });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2025, 4, 7, 0, 54, 15, 13, DateTimeKind.Local).AddTicks(3155), "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", 7.887366160007280m, 489.52m, "Handcrafted Rubber Mouse" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2025, 4, 7, 0, 54, 15, 13, DateTimeKind.Local).AddTicks(3275), "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", 9.049029247968840m, 768.91m, "Refined Granite Towels" });
        }
    }
}
