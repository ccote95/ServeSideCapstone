using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServerSideCapstone.Migrations
{
    /// <inheritdoc />
    public partial class ShoppingCartEdit2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserProfileId",
                table: "ShoppingCarts",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "357af7cc-d684-4950-aa8d-c73686bfbcb0", "AQAAAAIAAYagAAAAEJw9c2/bJjl5zquY61hacI6W++MYeHdBR1FfJuTUWFC7mNzfqhAGM2oI3FLfDYKh8A==", "08afcebb-1e6c-416a-b44a-5a7f44705f86" });

            migrationBuilder.UpdateData(
                table: "Listing",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 17, 13, 31, 21, 103, DateTimeKind.Local).AddTicks(6434));

            migrationBuilder.UpdateData(
                table: "Listing",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 14, 13, 31, 21, 103, DateTimeKind.Local).AddTicks(6486));

            migrationBuilder.UpdateData(
                table: "Listing",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 7, 13, 31, 21, 103, DateTimeKind.Local).AddTicks(6488));

            migrationBuilder.UpdateData(
                table: "Listing",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 11, 13, 31, 21, 103, DateTimeKind.Local).AddTicks(6491));

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_UserProfileId",
                table: "ShoppingCarts",
                column: "UserProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCarts_UserProfiles_UserProfileId",
                table: "ShoppingCarts",
                column: "UserProfileId",
                principalTable: "UserProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCarts_UserProfiles_UserProfileId",
                table: "ShoppingCarts");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingCarts_UserProfileId",
                table: "ShoppingCarts");

            migrationBuilder.DropColumn(
                name: "UserProfileId",
                table: "ShoppingCarts");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "163ff28a-717d-40a9-a817-cca96a7fce4d", "AQAAAAIAAYagAAAAEFQtRi0ENyLfQh5TXi1B1q1Hr3SEwJj70U8RyRHNlHqbJNHLTK+GZeGIRHfUMi6zcA==", "226aaac6-d81c-4aaf-a6b0-1929fba365fd" });

            migrationBuilder.UpdateData(
                table: "Listing",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 17, 12, 39, 54, 633, DateTimeKind.Local).AddTicks(3008));

            migrationBuilder.UpdateData(
                table: "Listing",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 14, 12, 39, 54, 633, DateTimeKind.Local).AddTicks(3065));

            migrationBuilder.UpdateData(
                table: "Listing",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 7, 12, 39, 54, 633, DateTimeKind.Local).AddTicks(3067));

            migrationBuilder.UpdateData(
                table: "Listing",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 11, 12, 39, 54, 633, DateTimeKind.Local).AddTicks(3070));
        }
    }
}
