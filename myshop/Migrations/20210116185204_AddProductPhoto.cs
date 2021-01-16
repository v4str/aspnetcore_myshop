using Microsoft.EntityFrameworkCore.Migrations;

namespace myshop.Migrations
{
    public partial class AddProductPhoto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerProduct_Products_ProductsId",
                table: "CustomerProduct");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Products",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "ProductsId",
                table: "CustomerProduct",
                newName: "ProductsProductId");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerProduct_ProductsId",
                table: "CustomerProduct",
                newName: "IX_CustomerProduct_ProductsProductId");

            migrationBuilder.CreateTable(
                name: "ProductPhotos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductPhotos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductPhotos_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductPhotos_ProductId",
                table: "ProductPhotos",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerProduct_Products_ProductsProductId",
                table: "CustomerProduct",
                column: "ProductsProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerProduct_Products_ProductsProductId",
                table: "CustomerProduct");

            migrationBuilder.DropTable(
                name: "ProductPhotos");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Products",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ProductsProductId",
                table: "CustomerProduct",
                newName: "ProductsId");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerProduct_ProductsProductId",
                table: "CustomerProduct",
                newName: "IX_CustomerProduct_ProductsId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerProduct_Products_ProductsId",
                table: "CustomerProduct",
                column: "ProductsId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
