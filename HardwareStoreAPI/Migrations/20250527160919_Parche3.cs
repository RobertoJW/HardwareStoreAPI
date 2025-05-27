using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HardwareStoreAPI.Migrations
{
    /// <inheritdoc />
    public partial class Parche3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Elimina la columna id_producto de la tabla ListaFavoritos
            migrationBuilder.DropColumn(
                name: "id_producto",
                table: "ListaFavoritos");

            // Crea la tabla de unión many-to-many entre ListaFavoritos y Productos
            migrationBuilder.CreateTable(
                name: "ListaFavoritosProductos",
                columns: table => new
                {
                    ListaFavoritosId = table.Column<int>(type: "int", nullable: false),
                    ProductoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListaFavoritosProductos", x => new { x.ListaFavoritosId, x.ProductoId });
                    table.ForeignKey(
                        name: "FK_ListaFavoritosProductos_ListaFavoritos_ListaFavoritosId",
                        column: x => x.ListaFavoritosId,
                        principalTable: "ListaFavoritos",
                        principalColumn: "id_favorito",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ListaFavoritosProductos_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "IdProducto",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ListaFavoritosProductos_ProductoId",
                table: "ListaFavoritosProductos",
                column: "ProductoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Elimina la tabla de unión
            migrationBuilder.DropTable(
                name: "ListaFavoritosProductos");

            // Restaura la columna id_producto en ListaFavoritos
            migrationBuilder.AddColumn<int>(
                name: "id_producto",
                table: "ListaFavoritos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
