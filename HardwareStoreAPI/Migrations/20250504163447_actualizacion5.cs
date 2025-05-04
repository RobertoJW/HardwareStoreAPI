using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HardwareStoreAPI.Migrations
{
    /// <inheritdoc />
    public partial class actualizacion5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductoTempId4",
                table: "Moviles");

            migrationBuilder.AddColumn<int>(
                name: "ProductoTempId41",
                table: "Moviles",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductoTempId41",
                table: "Moviles");

            migrationBuilder.AddColumn<int>(
                name: "ProductoTempId4",
                table: "Moviles",
                type: "int",
                nullable: true);
        }
    }
}
