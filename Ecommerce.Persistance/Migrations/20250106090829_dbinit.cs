using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class dbinit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    custId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    custName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    custEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    custPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    custAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    custCity = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.custId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    productId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    productDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    productPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    productStock = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.productId);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    orderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    orderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    orderStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    custId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.orderId);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_custId",
                        column: x => x.custId,
                        principalTable: "Customers",
                        principalColumn: "custId");
                });

            migrationBuilder.CreateTable(
                name: "OrderEntityProductEntity",
                columns: table => new
                {
                    OrderDetailsorderId = table.Column<int>(type: "int", nullable: false),
                    ProductsproductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderEntityProductEntity", x => new { x.OrderDetailsorderId, x.ProductsproductId });
                    table.ForeignKey(
                        name: "FK_OrderEntityProductEntity_Orders_OrderDetailsorderId",
                        column: x => x.OrderDetailsorderId,
                        principalTable: "Orders",
                        principalColumn: "orderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderEntityProductEntity_Products_ProductsproductId",
                        column: x => x.ProductsproductId,
                        principalTable: "Products",
                        principalColumn: "productId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderEntityProductEntity_ProductsproductId",
                table: "OrderEntityProductEntity",
                column: "ProductsproductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_custId",
                table: "Orders",
                column: "custId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderEntityProductEntity");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
