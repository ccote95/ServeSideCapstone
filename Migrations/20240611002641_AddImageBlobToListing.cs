using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServerSideCapstone.Migrations
{
    /// <inheritdoc />
    public partial class AddImageBlobToListing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImgLocation",
                table: "UserProfiles",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<byte[]>(
                name: "ImageBlob",
                table: "Listing",
                type: "bytea",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e5b56589-f299-4906-b18e-da92e9f712b0", "AQAAAAIAAYagAAAAEGc/XV62iayNdN6/s9GvUkNomjbp/TCpcnDxsI3aKTiaLrimjHuOkVEksChvQY/sIA==", "df70c844-928d-4595-b0a4-c2a0e14339b6" });

            migrationBuilder.UpdateData(
                table: "Listing",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "ImageBlob" },
                values: new object[] { new DateTime(2024, 6, 13, 20, 26, 41, 546, DateTimeKind.Local).AddTicks(5659), null });

            migrationBuilder.UpdateData(
                table: "Listing",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "ImageBlob" },
                values: new object[] { new DateTime(2024, 6, 10, 20, 26, 41, 546, DateTimeKind.Local).AddTicks(5706), null });

            migrationBuilder.UpdateData(
                table: "Listing",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "ImageBlob" },
                values: new object[] { new DateTime(2024, 6, 3, 20, 26, 41, 546, DateTimeKind.Local).AddTicks(5709), null });

            migrationBuilder.UpdateData(
                table: "Listing",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "ImageBlob" },
                values: new object[] { new DateTime(2024, 6, 7, 20, 26, 41, 546, DateTimeKind.Local).AddTicks(5712), null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageBlob",
                table: "Listing");

            migrationBuilder.AlterColumn<string>(
                name: "ImgLocation",
                table: "UserProfiles",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f3ad8e01-9cc8-4c0a-99e4-60b68244381d", "AQAAAAIAAYagAAAAEF6qqeS4UCWiCn8syYuFRlmz1P8H8K8D+1bqQ29+z7zheiqBFkwqrLvnpm/aG70liQ==", "c026ae4b-b5c1-44ad-8d6d-77da9435079b" });

            migrationBuilder.UpdateData(
                table: "Listing",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 11, 12, 59, 37, 269, DateTimeKind.Local).AddTicks(5920));

            migrationBuilder.UpdateData(
                table: "Listing",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 8, 12, 59, 37, 269, DateTimeKind.Local).AddTicks(5970));

            migrationBuilder.UpdateData(
                table: "Listing",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 1, 12, 59, 37, 269, DateTimeKind.Local).AddTicks(5972));

            migrationBuilder.UpdateData(
                table: "Listing",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 5, 12, 59, 37, 269, DateTimeKind.Local).AddTicks(5975));
        }
    }
}
