using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HardwareStoreAPI.Migrations
{
    public partial class actualizacion8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Eliminando columnas no necesarias
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

            // Creación de nuevas tablas con las relaciones adecuadas
            migrationBuilder.CreateTable(
                name: "Moviles",
                columns: table => new
                {
                    id_producto = table.Column<int>(type: "int", nullable: false),
                    pulgadas = table.Column<int>(type: "int", nullable: false),
                    Productoid_producto = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moviles", x => x.id_producto);
                    table.ForeignKey(
                        name: "FK_Moviles_Productos_Productoid_producto",
                        column: x => x.Productoid_producto,
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
                    tipoPc = table.Column<int>(type: "int", nullable: false),
                    pulgadas = table.Column<int>(type: "int", nullable: false),
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
                    tipoPc = table.Column<int>(type: "int", nullable: false),
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

            migrationBuilder.CreateIndex(
                name: "IX_Moviles_Productoid_producto",
                table: "Moviles",
                column: "Productoid_producto");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Eliminando tablas creadas
            migrationBuilder.DropTable(
                name: "Moviles");

            migrationBuilder.DropTable(
                name: "Portatiles");

            migrationBuilder.DropTable(
                name: "Sobremesas");

            // Reagregando las columnas eliminadas
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
    }
}
