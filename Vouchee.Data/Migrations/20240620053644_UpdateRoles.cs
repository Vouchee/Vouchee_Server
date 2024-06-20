using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Vouchee.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("6e823eb8-460f-4cff-a9b3-b99a4e5f36a8"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("afb3f9df-7904-49cf-93ba-c41e292ea8ab"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e2bb9d23-ebb6-4a3e-bb9f-8b9c4d60f813"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e69848ef-2c3c-45cf-907f-4dd11021529e"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("0afdc54a-cd33-4a96-8d40-4363f04641b0"), null, "Customer", "CUSTOMER" },
                    { new Guid("75633c19-d23a-4b64-9a0a-ca6040d146b5"), null, "Admin", "ADMIN" },
                    { new Guid("7d33b111-3114-4bab-802e-4c78a8c6fdca"), null, "Shop", "SHOP" },
                    { new Guid("9a5cffcc-5906-4354-998b-5b9e639c8d03"), null, "Staff", "STAFF" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("0afdc54a-cd33-4a96-8d40-4363f04641b0"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("75633c19-d23a-4b64-9a0a-ca6040d146b5"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7d33b111-3114-4bab-802e-4c78a8c6fdca"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("9a5cffcc-5906-4354-998b-5b9e639c8d03"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("6e823eb8-460f-4cff-a9b3-b99a4e5f36a8"), null, "Shop", "SHOP" },
                    { new Guid("afb3f9df-7904-49cf-93ba-c41e292ea8ab"), null, "Admin", "ADMIN" },
                    { new Guid("e2bb9d23-ebb6-4a3e-bb9f-8b9c4d60f813"), null, "Customer", "CUSTOMER" },
                    { new Guid("e69848ef-2c3c-45cf-907f-4dd11021529e"), null, "Staff", "STAFF" }
                });
        }
    }
}
