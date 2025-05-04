using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace HardwareStoreAPI.Migrations
{
    /// <inheritdoc />
    public partial class actualizacion3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductoTempId51",
                table: "Portatiles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductoTempId4",
                table: "Moviles",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DescripcionPortatilMovil",
                columns: table => new
                {
                    id_descripcionPortatilMovil = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    procesador = table.Column<string>(type: "longtext", nullable: false),
                    ram = table.Column<string>(type: "longtext", nullable: false),
                    almacenamiento = table.Column<string>(type: "longtext", nullable: false),
                    pantalla = table.Column<string>(type: "longtext", nullable: false),
                    tarjetaGrafica = table.Column<string>(type: "longtext", nullable: false),
                    sistemaOperativo = table.Column<string>(type: "longtext", nullable: false),
                    id_producto = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DescripcionPortatilMovil", x => x.id_descripcionPortatilMovil);
                    table.ForeignKey(
                        name: "FK_DescripcionPortatilMovil_Productos_id_producto",
                        column: x => x.id_producto,
                        principalTable: "Productos",
                        principalColumn: "id_producto",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DescripcionSobremesa",
                columns: table => new
                {
                    id_descripcionSobremesa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    procesador = table.Column<string>(type: "longtext", nullable: false),
                    ram = table.Column<string>(type: "longtext", nullable: false),
                    almacenamiento = table.Column<string>(type: "longtext", nullable: false),
                    tarjetaGrafica = table.Column<string>(type: "longtext", nullable: false),
                    fuentePoder = table.Column<string>(type: "longtext", nullable: false),
                    motherboard = table.Column<string>(type: "longtext", nullable: false),
                    refrigeracion = table.Column<string>(type: "longtext", nullable: false),
                    id_producto = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DescripcionSobremesa", x => x.id_descripcionSobremesa);
                    table.ForeignKey(
                        name: "FK_DescripcionSobremesa_Productos_id_producto",
                        column: x => x.id_producto,
                        principalTable: "Productos",
                        principalColumn: "id_producto",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_DescripcionPortatilMovil_id_producto",
                table: "DescripcionPortatilMovil",
                column: "id_producto",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DescripcionSobremesa_id_producto",
                table: "DescripcionSobremesa",
                column: "id_producto",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DescripcionPortatilMovil");

            migrationBuilder.DropTable(
                name: "DescripcionSobremesa");

            migrationBuilder.DropColumn(
                name: "ProductoTempId51",
                table: "Portatiles");

            migrationBuilder.DropColumn(
                name: "ProductoTempId4",
                table: "Moviles");
        }
    }
}
