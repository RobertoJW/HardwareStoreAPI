using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace HardwareStoreAPI.Migrations
{
    /// <inheritdoc />
    public partial class actualizacion1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Resolucion",
                table: "Portatiles",
                type: "longtext",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "Resolucion",
                table: "Moviles",
                type: "longtext",
                nullable: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Eliminar la columna 'Resolucion' de las tablas 'Moviles' y 'Portatiles'
            migrationBuilder.DropColumn(
                name: "Resolucion",
                table: "Moviles");

            migrationBuilder.DropColumn(
                name: "Resolucion",
                table: "Portatiles");
        }
    }
}
