using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderManagement.Repo.Migrations
{
    public partial class InitalCreateThree : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "3d028381-9152-4b35-af08-e61fc2ed68c4");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "93c5e9d7-423e-43ab-b5b2-58d4d6c8092b");

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5d17d623-a143-4d41-8ebb-32dd66530ab7", "1bf0e23e-3def-4cbe-b6e6-e1b77a476ddc", "Admin", null },
                    { "b175c05c-9ff0-4683-88a5-aa7381bb37c1", "fdc7411b-2268-4da1-8df4-3ad62fb2fca8", "User", null }
                });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 1,
                column: "InvoiceDate",
                value: new DateTime(2024, 7, 18, 18, 20, 35, 924, DateTimeKind.Local).AddTicks(1370));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 2,
                column: "InvoiceDate",
                value: new DateTime(2024, 7, 18, 18, 20, 35, 924, DateTimeKind.Local).AddTicks(1372));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2024, 7, 18, 18, 20, 35, 924, DateTimeKind.Local).AddTicks(1304));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2024, 7, 18, 18, 20, 35, 924, DateTimeKind.Local).AddTicks(1347));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "5d17d623-a143-4d41-8ebb-32dd66530ab7");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "b175c05c-9ff0-4683-88a5-aa7381bb37c1");

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3d028381-9152-4b35-af08-e61fc2ed68c4", "60813ec5-89ae-40b7-ad52-5ed5a95976e1", "User", null },
                    { "93c5e9d7-423e-43ab-b5b2-58d4d6c8092b", "ce9fd8cd-b3e6-4757-baaf-3f0b1c10157b", "Admin", null }
                });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 1,
                column: "InvoiceDate",
                value: new DateTime(2024, 7, 18, 18, 4, 6, 293, DateTimeKind.Local).AddTicks(4401));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 2,
                column: "InvoiceDate",
                value: new DateTime(2024, 7, 18, 18, 4, 6, 293, DateTimeKind.Local).AddTicks(4403));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2024, 7, 18, 18, 4, 6, 293, DateTimeKind.Local).AddTicks(4321));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2024, 7, 18, 18, 4, 6, 293, DateTimeKind.Local).AddTicks(4360));
        }
    }
}
