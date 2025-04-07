using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreOnionArchitecture.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InıtialCreate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Brands",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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
                columns: new[] { "CreatedDate", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2025, 4, 7, 0, 54, 15, 13, DateTimeKind.Local).AddTicks(3155), 7.887366160007280m, 489.52m, "Handcrafted Rubber Mouse" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2025, 4, 7, 0, 54, 15, 13, DateTimeKind.Local).AddTicks(3275), "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", 9.049029247968840m, 768.91m, "Refined Granite Towels" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "Products",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Brands",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2025, 4, 7, 0, 49, 31, 827, DateTimeKind.Local).AddTicks(4703), "Beauty, Computers & Kids" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2025, 4, 7, 0, 49, 31, 848, DateTimeKind.Local).AddTicks(6007), "Baby & Books" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2025, 4, 7, 0, 49, 31, 848, DateTimeKind.Local).AddTicks(6088), "Sports" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 4, 7, 0, 49, 31, 853, DateTimeKind.Local).AddTicks(1442));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 4, 7, 0, 49, 31, 853, DateTimeKind.Local).AddTicks(1458));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 4, 7, 0, 49, 31, 853, DateTimeKind.Local).AddTicks(1461));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2025, 4, 7, 0, 49, 31, 853, DateTimeKind.Local).AddTicks(1464));

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Description", "Title" },
                values: new object[] { new DateTime(2025, 4, 7, 0, 49, 31, 886, DateTimeKind.Local).AddTicks(4397), "Quia magnam sit aut temporibus.", "Commodi." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Description", "Title" },
                values: new object[] { new DateTime(2025, 4, 7, 0, 49, 31, 886, DateTimeKind.Local).AddTicks(4510), "Numquam voluptatem repellendus beatae consequatur.", "Aperiam ratione." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Description", "Title" },
                values: new object[] { new DateTime(2025, 4, 7, 0, 49, 31, 886, DateTimeKind.Local).AddTicks(4546), "İn vero cum consequatur sunt.", "Cum." });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2025, 4, 7, 0, 49, 31, 852, DateTimeKind.Local).AddTicks(7202), 8.749453108212850m, 702, "Handmade Wooden Towels" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2025, 4, 7, 0, 49, 31, 852, DateTimeKind.Local).AddTicks(7327), "The Football Is Good For Training And Recreational Purposes", 7.55414935258720m, 441, "Ergonomic Cotton Pizza" });
        }
    }
}
