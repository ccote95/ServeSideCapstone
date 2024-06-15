using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServerSideCapstone.Migrations
{
    /// <inheritdoc />
    public partial class ShoppingCartEdit5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Listing_ShoppingCarts_ShoppingCartId",
                table: "Listing");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingCarts_UserProfileId",
                table: "ShoppingCarts");

            migrationBuilder.DropIndex(
                name: "IX_Listing_ShoppingCartId",
                table: "Listing");

            migrationBuilder.DropColumn(
                name: "ShoppingCartId",
                table: "Listing");

            migrationBuilder.AddColumn<int>(
                name: "UserProfileId1",
                table: "ShoppingCarts",
                type: "integer",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cfd4c16d-15e3-4fb5-ac42-62077d342355", "AQAAAAIAAYagAAAAEM3AyWK37GGqFrtXyH+QfN7VXJlN/bmqpF73WyCrw9t+4wbdSC6bOMXT7CzSA1GDJA==", "42eb6209-81f1-4cfe-821c-3dd8b73e75a7" });

            migrationBuilder.UpdateData(
                table: "Listing",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 17, 15, 53, 27, 452, DateTimeKind.Local).AddTicks(9787));

            migrationBuilder.UpdateData(
                table: "Listing",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 14, 15, 53, 27, 452, DateTimeKind.Local).AddTicks(9899));

            migrationBuilder.UpdateData(
                table: "Listing",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 7, 15, 53, 27, 452, DateTimeKind.Local).AddTicks(9903));

            migrationBuilder.UpdateData(
                table: "Listing",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 11, 15, 53, 27, 452, DateTimeKind.Local).AddTicks(9905));

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_ListingId",
                table: "ShoppingCarts",
                column: "ListingId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_UserProfileId",
                table: "ShoppingCarts",
                column: "UserProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_UserProfileId1",
                table: "ShoppingCarts",
                column: "UserProfileId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCarts_Listing_ListingId",
                table: "ShoppingCarts",
                column: "ListingId",
                principalTable: "Listing",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCarts_UserProfiles_UserProfileId1",
                table: "ShoppingCarts",
                column: "UserProfileId1",
                principalTable: "UserProfiles",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCarts_Listing_ListingId",
                table: "ShoppingCarts");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCarts_UserProfiles_UserProfileId1",
                table: "ShoppingCarts");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingCarts_ListingId",
                table: "ShoppingCarts");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingCarts_UserProfileId",
                table: "ShoppingCarts");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingCarts_UserProfileId1",
                table: "ShoppingCarts");

            migrationBuilder.DropColumn(
                name: "UserProfileId1",
                table: "ShoppingCarts");

            migrationBuilder.AddColumn<int>(
                name: "ShoppingCartId",
                table: "Listing",
                type: "integer",
                nullable: true);

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
                columns: new[] { "CreatedOn", "ShoppingCartId" },
                values: new object[] { new DateTime(2024, 6, 17, 14, 46, 59, 439, DateTimeKind.Local).AddTicks(3233), null });

            migrationBuilder.UpdateData(
                table: "Listing",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "ShoppingCartId" },
                values: new object[] { new DateTime(2024, 6, 14, 14, 46, 59, 439, DateTimeKind.Local).AddTicks(3283), null });

            migrationBuilder.UpdateData(
                table: "Listing",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "ShoppingCartId" },
                values: new object[] { new DateTime(2024, 6, 7, 14, 46, 59, 439, DateTimeKind.Local).AddTicks(3286), null });

            migrationBuilder.UpdateData(
                table: "Listing",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "ShoppingCartId" },
                values: new object[] { new DateTime(2024, 6, 11, 14, 46, 59, 439, DateTimeKind.Local).AddTicks(3289), null });

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_UserProfileId",
                table: "ShoppingCarts",
                column: "UserProfileId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Listing_ShoppingCartId",
                table: "Listing",
                column: "ShoppingCartId");

            migrationBuilder.AddForeignKey(
                name: "FK_Listing_ShoppingCarts_ShoppingCartId",
                table: "Listing",
                column: "ShoppingCartId",
                principalTable: "ShoppingCarts",
                principalColumn: "Id");
        }
    }
}
