using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServerSideCapstone.Migrations
{
    /// <inheritdoc />
    public partial class ShoppingCartEdit3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCarts_Listing_listingId",
                table: "ShoppingCarts");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingCarts_listingId",
                table: "ShoppingCarts");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingCarts_UserProfileId",
                table: "ShoppingCarts");

            migrationBuilder.RenameColumn(
                name: "listingId",
                table: "ShoppingCarts",
                newName: "ListingId");

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
                values: new object[] { "a793d346-0ee0-4da4-94ae-fb5a11b6160a", "AQAAAAIAAYagAAAAEDWwcxN5Y88f1TJsZRSa8eS1i66J+nuFh/f7zoflsXAM/wOfDRiOAVR7l3coHZSEvA==", "4994e583-2b42-4fd2-b65a-d7fc55e1f7a9" });

            migrationBuilder.UpdateData(
                table: "Listing",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "ShoppingCartId" },
                values: new object[] { new DateTime(2024, 6, 17, 14, 43, 37, 151, DateTimeKind.Local).AddTicks(6069), null });

            migrationBuilder.UpdateData(
                table: "Listing",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "ShoppingCartId" },
                values: new object[] { new DateTime(2024, 6, 14, 14, 43, 37, 151, DateTimeKind.Local).AddTicks(6190), null });

            migrationBuilder.UpdateData(
                table: "Listing",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "ShoppingCartId" },
                values: new object[] { new DateTime(2024, 6, 7, 14, 43, 37, 151, DateTimeKind.Local).AddTicks(6196), null });

            migrationBuilder.UpdateData(
                table: "Listing",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "ShoppingCartId" },
                values: new object[] { new DateTime(2024, 6, 11, 14, 43, 37, 151, DateTimeKind.Local).AddTicks(6202), null });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "ListingId",
                table: "ShoppingCarts",
                newName: "listingId");

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
                name: "IX_ShoppingCarts_listingId",
                table: "ShoppingCarts",
                column: "listingId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_UserProfileId",
                table: "ShoppingCarts",
                column: "UserProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCarts_Listing_listingId",
                table: "ShoppingCarts",
                column: "listingId",
                principalTable: "Listing",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
