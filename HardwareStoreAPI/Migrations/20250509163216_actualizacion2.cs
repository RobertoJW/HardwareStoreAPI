using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HardwareStoreAPI.Migrations
{
    /// <inheritdoc />
    public partial class actualizacion2 : Migration
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
            migrationBuilder.DropColumn(
                name: "Resolucion",
                table: "Portatiles");

            migrationBuilder.DropColumn(
                name: "Resolucion",
                table: "Moviles");
        }
    }
}
