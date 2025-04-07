using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StoreOnionArchitecture.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Brands",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "IsDeleted", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 4, 7, 2, 16, 42, 567, DateTimeKind.Local).AddTicks(9889), null, false, "Kids, Electronics & Games", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2025, 4, 7, 2, 16, 42, 570, DateTimeKind.Local).AddTicks(4800), null, false, "Electronics, Home & Kids", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2025, 4, 7, 2, 16, 42, 570, DateTimeKind.Local).AddTicks(4854), null, true, "Shoes & Jewelery", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "IsDeleted", "Name", "ParentId", "Priorty", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 4, 7, 2, 16, 42, 571, DateTimeKind.Local).AddTicks(5336), null, false, "Elektrik", 0, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2025, 4, 7, 2, 16, 42, 571, DateTimeKind.Local).AddTicks(5354), null, false, "Moda", 0, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2025, 4, 7, 2, 16, 42, 571, DateTimeKind.Local).AddTicks(5359), null, false, "Bilgisayar", 1, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2025, 4, 7, 2, 16, 42, 571, DateTimeKind.Local).AddTicks(5363), null, false, "Kadın", 2, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Details",
                columns: new[] { "Id", "CategoryId", "CreatedDate", "DeletedDate", "Description", "IsDeleted", "Title", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 4, 7, 2, 16, 42, 588, DateTimeKind.Local).AddTicks(6948), null, "Gitti ea bilgisayarı velit quis.", false, "Consequatur.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 3, new DateTime(2025, 4, 7, 2, 16, 42, 588, DateTimeKind.Local).AddTicks(7050), null, "İn quam eum quis ex.", true, "Ama layıkıyla.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 4, new DateTime(2025, 4, 7, 2, 16, 42, 588, DateTimeKind.Local).AddTicks(7130), null, "Kutusu sandalye deleniti blanditiis et.", false, "Aliquid.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CreatedDate", "DeletedDate", "Description", "Discount", "IsDeleted", "Price", "Title", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 4, 7, 2, 16, 42, 591, DateTimeKind.Local).AddTicks(7257), null, "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", 3.152972498762230m, false, 51.62m, "Fantastic Granite Keyboard", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 3, new DateTime(2025, 4, 7, 2, 16, 42, 591, DateTimeKind.Local).AddTicks(7375), null, "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", 4.392930860190960m, false, 469.28m, "Handcrafted Metal Pizza", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Brands",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);
        }
    }
}
