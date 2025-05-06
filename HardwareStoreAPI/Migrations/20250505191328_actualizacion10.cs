using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace HardwareStoreAPI.Migrations
{
    /// <inheritdoc />
    public partial class actualizacion10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Moviles_Productos_Productoid_producto",
                table: "Moviles");

            migrationBuilder.DropForeignKey(
                name: "FK_Moviles_Productos_id_producto",
                table: "Moviles");

            migrationBuilder.DropForeignKey(
                name: "FK_Portatiles_Productos_Productoid_producto",
                table: "Portatiles");

            migrationBuilder.DropForeignKey(
                name: "FK_Portatiles_Productos_id_producto",
                table: "Portatiles");

            migrationBuilder.DropForeignKey(
                name: "FK_Sobremesas_Productos_Productoid_producto",
                table: "Sobremesas");

            migrationBuilder.DropForeignKey(
                name: "FK_Sobremesas_Productos_id_producto",
                table: "Sobremesas");

            migrationBuilder.DropTable(
                name: "DescripcionPortatilMovil");

            migrationBuilder.DropTable(
                name: "DescripcionSobremesa");

            migrationBuilder.DropIndex(
                name: "IX_Sobremesas_Productoid_producto",
                table: "Sobremesas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Portatiles",
                table: "Portatiles");

            migrationBuilder.DropIndex(
                name: "IX_Portatiles_Productoid_producto",
                table: "Portatiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Moviles",
                table: "Moviles");

            migrationBuilder.DropIndex(
                name: "IX_Moviles_Productoid_producto",
                table: "Moviles");

            migrationBuilder.DropColumn(
                name: "Productoid_producto",
                table: "Sobremesas");

            migrationBuilder.DropColumn(
                name: "price",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "Productoid_producto",
                table: "Portatiles");

            migrationBuilder.DropColumn(
                name: "Productoid_producto",
                table: "Moviles");

            migrationBuilder.RenameColumn(
                name: "id_producto",
                table: "Sobremesas",
                newName: "IdProducto");

            migrationBuilder.RenameColumn(
                name: "nameProduct",
                table: "Productos",
                newName: "NombreProducto");

            migrationBuilder.RenameColumn(
                name: "imageUrl",
                table: "Productos",
                newName: "NombreEmpresa");

            migrationBuilder.RenameColumn(
                name: "companyBrand",
                table: "Productos",
                newName: "ImagenUrl");

            migrationBuilder.RenameColumn(
                name: "category",
                table: "Productos",
                newName: "Categoria");

            migrationBuilder.RenameColumn(
                name: "id_producto",
                table: "Productos",
                newName: "IdProducto");

            migrationBuilder.RenameColumn(
                name: "pulgadas",
                table: "Portatiles",
                newName: "Pulgadas");

            migrationBuilder.RenameColumn(
                name: "id_producto",
                table: "Portatiles",
                newName: "Bateria");

            migrationBuilder.RenameColumn(
                name: "pulgadas",
                table: "Moviles",
                newName: "Pulgadas");

            migrationBuilder.RenameColumn(
                name: "id_producto",
                table: "Moviles",
                newName: "Camara");

            migrationBuilder.AddColumn<decimal>(
                name: "Precio",
                table: "Productos",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "IdProducto",
                table: "Portatiles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdProducto",
                table: "Moviles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Bateria",
                table: "Moviles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Portatiles",
                table: "Portatiles",
                column: "IdProducto");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Moviles",
                table: "Moviles",
                column: "IdProducto");

            migrationBuilder.CreateTable(
                name: "DescripcionGeneral",
                columns: table => new
                {
                    IdDescripcionGeneral = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    IdProducto = table.Column<int>(type: "int", nullable: false),
                    CPU = table.Column<string>(type: "longtext", nullable: false),
                    RAM = table.Column<string>(type: "longtext", nullable: false),
                    GPU = table.Column<string>(type: "longtext", nullable: false),
                    Almacenamiento = table.Column<string>(type: "longtext", nullable: false),
                    SistemaOperativo = table.Column<string>(type: "longtext", nullable: false),
                    PlacaBase = table.Column<string>(type: "longtext", nullable: false),
                    Peso = table.Column<double>(type: "double", nullable: false),
                    Dimensiones = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DescripcionGeneral", x => x.IdDescripcionGeneral);
                    table.ForeignKey(
                        name: "FK_DescripcionGeneral_Productos_IdProducto",
                        column: x => x.IdProducto,
                        principalTable: "Productos",
                        principalColumn: "IdProducto",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_DescripcionGeneral_IdProducto",
                table: "DescripcionGeneral",
                column: "IdProducto",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Moviles_Productos_IdProducto",
                table: "Moviles",
                column: "IdProducto",
                principalTable: "Productos",
                principalColumn: "IdProducto",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Portatiles_Productos_IdProducto",
                table: "Portatiles",
                column: "IdProducto",
                principalTable: "Productos",
                principalColumn: "IdProducto",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sobremesas_Productos_IdProducto",
                table: "Sobremesas",
                column: "IdProducto",
                principalTable: "Productos",
                principalColumn: "IdProducto",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Moviles_Productos_IdProducto",
                table: "Moviles");

            migrationBuilder.DropForeignKey(
                name: "FK_Portatiles_Productos_IdProducto",
                table: "Portatiles");

            migrationBuilder.DropForeignKey(
                name: "FK_Sobremesas_Productos_IdProducto",
                table: "Sobremesas");

            migrationBuilder.DropTable(
                name: "DescripcionGeneral");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Portatiles",
                table: "Portatiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Moviles",
                table: "Moviles");

            migrationBuilder.DropColumn(
                name: "Precio",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "IdProducto",
                table: "Portatiles");

            migrationBuilder.DropColumn(
                name: "IdProducto",
                table: "Moviles");

            migrationBuilder.DropColumn(
                name: "Bateria",
                table: "Moviles");

            migrationBuilder.RenameColumn(
                name: "IdProducto",
                table: "Sobremesas",
                newName: "id_producto");

            migrationBuilder.RenameColumn(
                name: "NombreProducto",
                table: "Productos",
                newName: "nameProduct");

            migrationBuilder.RenameColumn(
                name: "NombreEmpresa",
                table: "Productos",
                newName: "imageUrl");

            migrationBuilder.RenameColumn(
                name: "ImagenUrl",
                table: "Productos",
                newName: "companyBrand");

            migrationBuilder.RenameColumn(
                name: "Categoria",
                table: "Productos",
                newName: "category");

            migrationBuilder.RenameColumn(
                name: "IdProducto",
                table: "Productos",
                newName: "id_producto");

            migrationBuilder.RenameColumn(
                name: "Pulgadas",
                table: "Portatiles",
                newName: "pulgadas");

            migrationBuilder.RenameColumn(
                name: "Bateria",
                table: "Portatiles",
                newName: "id_producto");

            migrationBuilder.RenameColumn(
                name: "Pulgadas",
                table: "Moviles",
                newName: "pulgadas");

            migrationBuilder.RenameColumn(
                name: "Camara",
                table: "Moviles",
                newName: "id_producto");

            migrationBuilder.AddColumn<int>(
                name: "Productoid_producto",
                table: "Sobremesas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "price",
                table: "Productos",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "Productoid_producto",
                table: "Portatiles",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Productoid_producto",
                table: "Moviles",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Portatiles",
                table: "Portatiles",
                column: "id_producto");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Moviles",
                table: "Moviles",
                column: "id_producto");

            migrationBuilder.CreateTable(
                name: "DescripcionPortatilMovil",
                columns: table => new
                {
                    id_descripcionPortatilMovil = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    id_producto = table.Column<int>(type: "int", nullable: false),
                    almacenamiento = table.Column<string>(type: "longtext", nullable: false),
                    pantalla = table.Column<string>(type: "longtext", nullable: false),
                    procesador = table.Column<string>(type: "longtext", nullable: false),
                    ram = table.Column<string>(type: "longtext", nullable: false),
                    sistemaOperativo = table.Column<string>(type: "longtext", nullable: false),
                    tarjetaGrafica = table.Column<string>(type: "longtext", nullable: false)
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
                    id_producto = table.Column<int>(type: "int", nullable: false),
                    almacenamiento = table.Column<string>(type: "longtext", nullable: false),
                    fuentePoder = table.Column<string>(type: "longtext", nullable: false),
                    motherboard = table.Column<string>(type: "longtext", nullable: false),
                    procesador = table.Column<string>(type: "longtext", nullable: false),
                    ram = table.Column<string>(type: "longtext", nullable: false),
                    refrigeracion = table.Column<string>(type: "longtext", nullable: false),
                    tarjetaGrafica = table.Column<string>(type: "longtext", nullable: false)
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
                name: "IX_Sobremesas_Productoid_producto",
                table: "Sobremesas",
                column: "Productoid_producto");

            migrationBuilder.CreateIndex(
                name: "IX_Portatiles_Productoid_producto",
                table: "Portatiles",
                column: "Productoid_producto");

            migrationBuilder.CreateIndex(
                name: "IX_Moviles_Productoid_producto",
                table: "Moviles",
                column: "Productoid_producto");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Moviles_Productos_Productoid_producto",
                table: "Moviles",
                column: "Productoid_producto",
                principalTable: "Productos",
                principalColumn: "id_producto");

            migrationBuilder.AddForeignKey(
                name: "FK_Moviles_Productos_id_producto",
                table: "Moviles",
                column: "id_producto",
                principalTable: "Productos",
                principalColumn: "id_producto",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Portatiles_Productos_Productoid_producto",
                table: "Portatiles",
                column: "Productoid_producto",
                principalTable: "Productos",
                principalColumn: "id_producto");

            migrationBuilder.AddForeignKey(
                name: "FK_Portatiles_Productos_id_producto",
                table: "Portatiles",
                column: "id_producto",
                principalTable: "Productos",
                principalColumn: "id_producto",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sobremesas_Productos_Productoid_producto",
                table: "Sobremesas",
                column: "Productoid_producto",
                principalTable: "Productos",
                principalColumn: "id_producto");

            migrationBuilder.AddForeignKey(
                name: "FK_Sobremesas_Productos_id_producto",
                table: "Sobremesas",
                column: "id_producto",
                principalTable: "Productos",
                principalColumn: "id_producto",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
