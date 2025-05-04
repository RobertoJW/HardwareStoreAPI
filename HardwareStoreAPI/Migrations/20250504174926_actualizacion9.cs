using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HardwareStoreAPI.Migrations
{
    /// <inheritdoc />
    public partial class actualizacion9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductoTempId6",
                table: "Sobremesas");

            migrationBuilder.DropColumn(
                name: "ProductoTempId5",
                table: "Portatiles");

            migrationBuilder.AddColumn<int>(
                name: "Productoid_producto",
                table: "Sobremesas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Productoid_producto",
                table: "Portatiles",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sobremesas_Productoid_producto",
                table: "Sobremesas",
                column: "Productoid_producto");

            migrationBuilder.CreateIndex(
                name: "IX_Portatiles_Productoid_producto",
                table: "Portatiles",
                column: "Productoid_producto");

            migrationBuilder.AddForeignKey(
                name: "FK_Portatiles_Productos_Productoid_producto",
                table: "Portatiles",
                column: "Productoid_producto",
                principalTable: "Productos",
                principalColumn: "id_producto");

            migrationBuilder.AddForeignKey(
                name: "FK_Sobremesas_Productos_Productoid_producto",
                table: "Sobremesas",
                column: "Productoid_producto",
                principalTable: "Productos",
                principalColumn: "id_producto");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Portatiles_Productos_Productoid_producto",
                table: "Portatiles");

            migrationBuilder.DropForeignKey(
                name: "FK_Sobremesas_Productos_Productoid_producto",
                table: "Sobremesas");

            migrationBuilder.DropIndex(
                name: "IX_Sobremesas_Productoid_producto",
                table: "Sobremesas");

            migrationBuilder.DropIndex(
                name: "IX_Portatiles_Productoid_producto",
                table: "Portatiles");

            migrationBuilder.DropColumn(
                name: "Productoid_producto",
                table: "Sobremesas");

            migrationBuilder.DropColumn(
                name: "Productoid_producto",
                table: "Portatiles");

            migrationBuilder.AddColumn<int>(
                name: "ProductoTempId6",
                table: "Sobremesas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductoTempId5",
                table: "Portatiles",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
