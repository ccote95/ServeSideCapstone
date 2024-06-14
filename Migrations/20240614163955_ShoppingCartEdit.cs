using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServerSideCapstone.Migrations
{
    /// <inheritdoc />
    public partial class ShoppingCartEdit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Listing_ShoppingCarts_ShoppingCartId",
                table: "Listing");

            migrationBuilder.DropIndex(
                name: "IX_Listing_ShoppingCartId",
                table: "Listing");

            migrationBuilder.DropColumn(
                name: "ShoppingCartId",
                table: "Listing");

            migrationBuilder.AddColumn<int>(
                name: "listingId",
                table: "ShoppingCarts",
                type: "integer",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_listingId",
                table: "ShoppingCarts",
                column: "listingId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCarts_Listing_listingId",
                table: "ShoppingCarts",
                column: "listingId",
                principalTable: "Listing",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCarts_Listing_listingId",
                table: "ShoppingCarts");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingCarts_listingId",
                table: "ShoppingCarts");

            migrationBuilder.DropColumn(
                name: "listingId",
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
                values: new object[] { "10b63452-8304-4304-a153-aa80c3d7b942", "AQAAAAIAAYagAAAAEGoV0zbR02rH+WpbTBYZyEEcBI8A11AJc/PZeS18r2wjaBYC1TnpxI1Unz2p0Wdb6w==", "019273d1-a7f2-475e-8906-71a712768d91" });

            migrationBuilder.UpdateData(
                table: "Listing",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "ShoppingCartId" },
                values: new object[] { new DateTime(2024, 6, 17, 10, 6, 28, 933, DateTimeKind.Local).AddTicks(9836), null });

            migrationBuilder.UpdateData(
                table: "Listing",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "ShoppingCartId" },
                values: new object[] { new DateTime(2024, 6, 14, 10, 6, 28, 933, DateTimeKind.Local).AddTicks(9897), null });

            migrationBuilder.UpdateData(
                table: "Listing",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "ShoppingCartId" },
                values: new object[] { new DateTime(2024, 6, 7, 10, 6, 28, 933, DateTimeKind.Local).AddTicks(9902), null });

            migrationBuilder.UpdateData(
                table: "Listing",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "ShoppingCartId" },
                values: new object[] { new DateTime(2024, 6, 11, 10, 6, 28, 933, DateTimeKind.Local).AddTicks(9906), null });

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
