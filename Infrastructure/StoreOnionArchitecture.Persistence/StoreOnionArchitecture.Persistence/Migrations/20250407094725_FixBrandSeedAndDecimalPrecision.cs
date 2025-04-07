using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreOnionArchitecture.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class FixBrandSeedAndDecimalPrecision : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                values: new object[] { new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Apple" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Samsung" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "IsDeleted", "Name" },
                values: new object[] { new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Sony" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Elektronik" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bilgisayar" });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Description", "Title" },
                values: new object[] { new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bu ürün, yüksek performans sunar.", "Gelişmiş" });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Description", "Title" },
                values: new object[] { new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Taşınabilirlik açısından oldukça uygundur.", "Hafif" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Description", "Price", "Title" },
                values: new object[] { new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yüksek çözünürlüklü kamera ve hızlı işlemci ile donatılmıştır.", 1250.00m, "Akıllı Telefon" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Description", "Price", "Title" },
                values: new object[] { new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Uzun pil ömrü ve yüksek ses kalitesi sunar.", 850.00m, "Kablosuz Kulaklık" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                values: new object[] { new DateTime(2025, 4, 7, 2, 39, 50, 565, DateTimeKind.Local).AddTicks(3582), "Outdoors & Outdoors" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2025, 4, 7, 2, 39, 50, 567, DateTimeKind.Local).AddTicks(7879), "Garden, Garden & Computers" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "IsDeleted", "Name" },
                values: new object[] { new DateTime(2025, 4, 7, 2, 39, 50, 567, DateTimeKind.Local).AddTicks(7933), true, "Games & Jewelery" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2025, 4, 7, 2, 39, 50, 570, DateTimeKind.Local).AddTicks(6039), "Jewelery" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2025, 4, 7, 2, 39, 50, 570, DateTimeKind.Local).AddTicks(6087), "Music" });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Description", "Title" },
                values: new object[] { new DateTime(2025, 4, 7, 2, 39, 50, 588, DateTimeKind.Local).AddTicks(6097), "Mıknatıslı layıkıyla uzattı aut lakin ona modi quae voluptas sevindi.", "Intelligent" });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Description", "Title" },
                values: new object[] { new DateTime(2025, 4, 7, 2, 39, 50, 588, DateTimeKind.Local).AddTicks(6412), "Yapacakmış sunt consequatur yaptı cezbelendi koşuyorlar.", "Ergonomic" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Description", "Price", "Title" },
                values: new object[] { new DateTime(2025, 4, 7, 2, 39, 50, 595, DateTimeKind.Local).AddTicks(4406), "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", 658.43m, "Practical Granite Pizza" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Description", "Price", "Title" },
                values: new object[] { new DateTime(2025, 4, 7, 2, 39, 50, 595, DateTimeKind.Local).AddTicks(4617), "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", 1039.68m, "Gorgeous Cotton Soap" });
        }
    }
}
