using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HardwareStoreAPI.Migrations
{
    /// <inheritdoc />
    public partial class actualizacion6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Moviles");

            migrationBuilder.DropTable(
                name: "Portatiles");

            migrationBuilder.DropTable(
                name: "Sobremesas");

            migrationBuilder.AddColumn<int>(
                name: "Movil_pulgadas",
                table: "Productos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductoTempId5",
                table: "Productos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductoTempId6",
                table: "Productos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductoType",
                table: "Productos",
                type: "varchar(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Productoid_producto",
                table: "Productos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sobremesa_tipoPc",
                table: "Productos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "pulgadas",
                table: "Productos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "tipoPc",
                table: "Productos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Productos_Productoid_producto",
                table: "Productos",
                column: "Productoid_producto");

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Productos_Productoid_producto",
                table: "Productos",
                column: "Productoid_producto",
                principalTable: "Productos",
                principalColumn: "id_producto");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Productos_Productoid_producto",
                table: "Productos");

            migrationBuilder.DropIndex(
                name: "IX_Productos_Productoid_producto",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "Movil_pulgadas",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "ProductoTempId5",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "ProductoTempId6",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "ProductoType",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "Productoid_producto",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "Sobremesa_tipoPc",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "pulgadas",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "tipoPc",
                table: "Productos");

            migrationBuilder.CreateTable(
                name: "Moviles",
                columns: table => new
                {
                    id_producto = table.Column<int>(type: "int", nullable: false),
                    ProductoTempId41 = table.Column<int>(type: "int", nullable: false),
                    pulgadas = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moviles", x => x.id_producto);
                    table.ForeignKey(
                        name: "FK_Moviles_Productos_id_producto",
                        column: x => x.id_producto,
                        principalTable: "Productos",
                        principalColumn: "id_producto",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Portatiles",
                columns: table => new
                {
                    id_producto = table.Column<int>(type: "int", nullable: false),
                    ProductoTempId51 = table.Column<int>(type: "int", nullable: false),
                    pulgadas = table.Column<int>(type: "int", nullable: false),
                    tipoPc = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Portatiles", x => x.id_producto);
                    table.ForeignKey(
                        name: "FK_Portatiles_Productos_id_producto",
                        column: x => x.id_producto,
                        principalTable: "Productos",
                        principalColumn: "id_producto",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Sobremesas",
                columns: table => new
                {
                    id_producto = table.Column<int>(type: "int", nullable: false),
                    tipoPc = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sobremesas", x => x.id_producto);
                    table.ForeignKey(
                        name: "FK_Sobremesas_Productos_id_producto",
                        column: x => x.id_producto,
                        principalTable: "Productos",
                        principalColumn: "id_producto",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");
        }
    }
}
