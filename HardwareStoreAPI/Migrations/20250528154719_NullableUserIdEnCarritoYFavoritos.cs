using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HardwareStoreAPI.Migrations
{
    /// <inheritdoc />
    public partial class NullableUserIdEnCarritoYFavoritos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarritoCompras_Usuarios_userId",
                table: "CarritoCompras");

            migrationBuilder.DropForeignKey(
                name: "FK_ListaFavoritos_Usuarios_userId",
                table: "ListaFavoritos");

            migrationBuilder.AlterColumn<int>(
                name: "userId",
                table: "ListaFavoritos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "userId",
                table: "CarritoCompras",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_CarritoCompras_Usuarios_userId",
                table: "CarritoCompras",
                column: "userId",
                principalTable: "Usuarios",
                principalColumn: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_ListaFavoritos_Usuarios_userId",
                table: "ListaFavoritos",
                column: "userId",
                principalTable: "Usuarios",
                principalColumn: "userId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarritoCompras_Usuarios_userId",
                table: "CarritoCompras");

            migrationBuilder.DropForeignKey(
                name: "FK_ListaFavoritos_Usuarios_userId",
                table: "ListaFavoritos");

            migrationBuilder.AlterColumn<int>(
                name: "userId",
                table: "ListaFavoritos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "userId",
                table: "CarritoCompras",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CarritoCompras_Usuarios_userId",
                table: "CarritoCompras",
                column: "userId",
                principalTable: "Usuarios",
                principalColumn: "userId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ListaFavoritos_Usuarios_userId",
                table: "ListaFavoritos",
                column: "userId",
                principalTable: "Usuarios",
                principalColumn: "userId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
