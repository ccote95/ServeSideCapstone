using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServerSideCapstone.Migrations
{
    /// <inheritdoc />
    public partial class ShoppingCartEdit4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProfiles_AspNetUsers_IdentityUserId",
                table: "UserProfiles");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "UserProfiles",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "IdentityUserId",
                table: "UserProfiles",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "UserProfiles",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "UserProfiles",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Listing",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0a4f255f-b30c-4306-8cfe-628389647114", "AQAAAAIAAYagAAAAEPBUKWqSiB1R8EdhKg/nYfaew0ZP+a9cbONA0PfLuu9nZq41x5fha1MdTbCBg0AzfQ==", "8a055576-1a7e-4d56-b832-c0a04330087b" });

            migrationBuilder.UpdateData(
                table: "Listing",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 17, 14, 46, 59, 439, DateTimeKind.Local).AddTicks(3233));

            migrationBuilder.UpdateData(
                table: "Listing",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 14, 14, 46, 59, 439, DateTimeKind.Local).AddTicks(3283));

            migrationBuilder.UpdateData(
                table: "Listing",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 7, 14, 46, 59, 439, DateTimeKind.Local).AddTicks(3286));

            migrationBuilder.UpdateData(
                table: "Listing",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 11, 14, 46, 59, 439, DateTimeKind.Local).AddTicks(3289));

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfiles_AspNetUsers_IdentityUserId",
                table: "UserProfiles",
                column: "IdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProfiles_AspNetUsers_IdentityUserId",
                table: "UserProfiles");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "UserProfiles",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IdentityUserId",
                table: "UserProfiles",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "UserProfiles",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "UserProfiles",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Listing",
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
                values: new object[] { "a793d346-0ee0-4da4-94ae-fb5a11b6160a", "AQAAAAIAAYagAAAAEDWwcxN5Y88f1TJsZRSa8eS1i66J+nuFh/f7zoflsXAM/wOfDRiOAVR7l3coHZSEvA==", "4994e583-2b42-4fd2-b65a-d7fc55e1f7a9" });

            migrationBuilder.UpdateData(
                table: "Listing",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 17, 14, 43, 37, 151, DateTimeKind.Local).AddTicks(6069));

            migrationBuilder.UpdateData(
                table: "Listing",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 14, 14, 43, 37, 151, DateTimeKind.Local).AddTicks(6190));

            migrationBuilder.UpdateData(
                table: "Listing",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 7, 14, 43, 37, 151, DateTimeKind.Local).AddTicks(6196));

            migrationBuilder.UpdateData(
                table: "Listing",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 11, 14, 43, 37, 151, DateTimeKind.Local).AddTicks(6202));

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfiles_AspNetUsers_IdentityUserId",
                table: "UserProfiles",
                column: "IdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
