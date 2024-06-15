using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ServerSideCapstone.Migrations
{
    /// <inheritdoc />
    public partial class ShoppingCart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ProductImg",
                table: "Listing",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<int>(
                name: "ShoppingCartId",
                table: "Listing",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PaymentDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserProfileId = table.Column<int>(type: "integer", nullable: false),
                    CreditCardNumber = table.Column<int>(type: "integer", nullable: false),
                    CreditCardExperation = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlacedOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ShoppingCartId = table.Column<int>(type: "integer", nullable: false),
                    UserPaymentDetailsId = table.Column<int>(type: "integer", nullable: false),
                    PlacedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlacedOrders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCarts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Total = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCarts", x => x.Id);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Listing_ShoppingCarts_ShoppingCartId",
                table: "Listing");

            migrationBuilder.DropTable(
                name: "PaymentDetails");

            migrationBuilder.DropTable(
                name: "PlacedOrders");

            migrationBuilder.DropTable(
                name: "ShoppingCarts");

            migrationBuilder.DropIndex(
                name: "IX_Listing_ShoppingCartId",
                table: "Listing");

            migrationBuilder.DropColumn(
                name: "ShoppingCartId",
                table: "Listing");

            migrationBuilder.AlterColumn<string>(
                name: "ProductImg",
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
                values: new object[] { "e5b56589-f299-4906-b18e-da92e9f712b0", "AQAAAAIAAYagAAAAEGc/XV62iayNdN6/s9GvUkNomjbp/TCpcnDxsI3aKTiaLrimjHuOkVEksChvQY/sIA==", "df70c844-928d-4595-b0a4-c2a0e14339b6" });

            migrationBuilder.UpdateData(
                table: "Listing",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 13, 20, 26, 41, 546, DateTimeKind.Local).AddTicks(5659));

            migrationBuilder.UpdateData(
                table: "Listing",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 10, 20, 26, 41, 546, DateTimeKind.Local).AddTicks(5706));

            migrationBuilder.UpdateData(
                table: "Listing",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 3, 20, 26, 41, 546, DateTimeKind.Local).AddTicks(5709));

            migrationBuilder.UpdateData(
                table: "Listing",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 7, 20, 26, 41, 546, DateTimeKind.Local).AddTicks(5712));
        }
    }
}
