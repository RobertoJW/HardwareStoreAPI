using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace HardwareStoreAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    IdProducto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ImagenUrl = table.Column<string>(type: "longtext", nullable: false),
                    NombreEmpresa = table.Column<string>(type: "longtext", nullable: false),
                    NombreProducto = table.Column<string>(type: "longtext", nullable: false),
                    Categoria = table.Column<string>(type: "longtext", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.IdProducto);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    userId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    email = table.Column<string>(type: "longtext", nullable: false),
                    userName = table.Column<string>(type: "longtext", nullable: false),
                    password = table.Column<string>(type: "longtext", nullable: false),
                    UrlprofilePhoto = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.userId);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

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

            migrationBuilder.CreateTable(
                name: "Moviles",
                columns: table => new
                {
                    IdProducto = table.Column<int>(type: "int", nullable: false),
                    Pulgadas = table.Column<int>(type: "int", nullable: false),
                    Bateria = table.Column<int>(type: "int", nullable: false),
                    Camara = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moviles", x => x.IdProducto);
                    table.ForeignKey(
                        name: "FK_Moviles_Productos_IdProducto",
                        column: x => x.IdProducto,
                        principalTable: "Productos",
                        principalColumn: "IdProducto",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Portatiles",
                columns: table => new
                {
                    IdProducto = table.Column<int>(type: "int", nullable: false),
                    tipoPc = table.Column<int>(type: "int", nullable: false),
                    Pulgadas = table.Column<int>(type: "int", nullable: false),
                    Bateria = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Portatiles", x => x.IdProducto);
                    table.ForeignKey(
                        name: "FK_Portatiles_Productos_IdProducto",
                        column: x => x.IdProducto,
                        principalTable: "Productos",
                        principalColumn: "IdProducto",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Sobremesas",
                columns: table => new
                {
                    IdProducto = table.Column<int>(type: "int", nullable: false),
                    tipoPc = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sobremesas", x => x.IdProducto);
                    table.ForeignKey(
                        name: "FK_Sobremesas_Productos_IdProducto",
                        column: x => x.IdProducto,
                        principalTable: "Productos",
                        principalColumn: "IdProducto",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CarritoCompras",
                columns: table => new
                {
                    id_carrito = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    cantidad = table.Column<int>(type: "int", nullable: false),
                    id_producto = table.Column<int>(type: "int", nullable: false),
                    userId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarritoCompras", x => x.id_carrito);
                    table.ForeignKey(
                        name: "FK_CarritoCompras_Productos_id_producto",
                        column: x => x.id_producto,
                        principalTable: "Productos",
                        principalColumn: "IdProducto",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarritoCompras_Usuarios_userId",
                        column: x => x.userId,
                        principalTable: "Usuarios",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ListaFavoritos",
                columns: table => new
                {
                    id_favorito = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    userId = table.Column<int>(type: "int", nullable: false),
                    id_producto = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListaFavoritos", x => x.id_favorito);
                    table.ForeignKey(
                        name: "FK_ListaFavoritos_Productos_id_producto",
                        column: x => x.id_producto,
                        principalTable: "Productos",
                        principalColumn: "IdProducto",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ListaFavoritos_Usuarios_userId",
                        column: x => x.userId,
                        principalTable: "Usuarios",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_CarritoCompras_id_producto",
                table: "CarritoCompras",
                column: "id_producto");

            migrationBuilder.CreateIndex(
                name: "IX_CarritoCompras_userId",
                table: "CarritoCompras",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_DescripcionGeneral_IdProducto",
                table: "DescripcionGeneral",
                column: "IdProducto",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ListaFavoritos_id_producto",
                table: "ListaFavoritos",
                column: "id_producto");

            migrationBuilder.CreateIndex(
                name: "IX_ListaFavoritos_userId",
                table: "ListaFavoritos",
                column: "userId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarritoCompras");

            migrationBuilder.DropTable(
                name: "DescripcionGeneral");

            migrationBuilder.DropTable(
                name: "ListaFavoritos");

            migrationBuilder.DropTable(
                name: "Moviles");

            migrationBuilder.DropTable(
                name: "Portatiles");

            migrationBuilder.DropTable(
                name: "Sobremesas");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Productos");
        }
    }
}
