using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Vouchee.Data.Migrations
{
    /// <inheritdoc />
    public partial class updatetransaction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<DateTime>(
                name: "TransactionDateTime",
                table: "Transaction",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<Guid>(
                name: "WalletId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("613e8085-f232-4187-9454-fced201b1c3c"), null, "Admin", "ADMIN" },
                    { new Guid("6b852a61-1f84-4c9f-8f19-79134ae233a4"), null, "Shop", "SHOP" },
                    { new Guid("b2b11867-ca82-4035-a876-c0fa314e2af7"), null, "Customer", "CUSTOMER" },
                    { new Guid("c3665c24-db2e-422c-bbe1-758230a07fff"), null, "Staff", "STAFF" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("613e8085-f232-4187-9454-fced201b1c3c"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("6b852a61-1f84-4c9f-8f19-79134ae233a4"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b2b11867-ca82-4035-a876-c0fa314e2af7"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c3665c24-db2e-422c-bbe1-758230a07fff"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "TransactionDateTime",
                table: "Transaction",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "WalletId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

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
    }
}
