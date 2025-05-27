using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HardwareStoreAPI.Migrations
{
    /// <inheritdoc />
    public partial class Parche4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        { 
            migrationBuilder.CreateTable(
                name: "CarritoCompraProductos",
                columns: table => new
                {
                    CarritoCompraId = table.Column<int>(type: "int", nullable: false),
                    ProductoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarritoCompraProductos", x => new { x.CarritoCompraId, x.ProductoId });
                    table.ForeignKey(
                        name: "FK_CarritoCompraProductos_CarritoCompras_CarritoCompraId",
                        column: x => x.CarritoCompraId,
                        principalTable: "CarritoCompras",
                        principalColumn: "id_carrito",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarritoCompraProductos_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "IdProducto",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_CarritoCompraProductos_ProductoId",
                table: "CarritoCompraProductos",
                column: "ProductoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarritoCompraProductos");

            migrationBuilder.AddColumn<int>(
                name: "id_producto",
                table: "CarritoCompras",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CarritoCompras_id_producto",
                table: "CarritoCompras",
                column: "id_producto");

            migrationBuilder.AddForeignKey(
                name: "FK_CarritoCompras_Productos_id_producto",
                table: "CarritoCompras",
                column: "id_producto",
                principalTable: "Productos",
                principalColumn: "IdProducto",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
