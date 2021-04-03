using Microsoft.EntityFrameworkCore.Migrations;

namespace CupcakeShop.Web.Migrations
{
    public partial class ClientAddCartRelationMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart_Clients_ClientId",
                table: "Cart");

            migrationBuilder.DropIndex(
                name: "IX_Cart_ClientId",
                table: "Cart");

            migrationBuilder.AlterColumn<int>(
                name: "ClientId",
                table: "Cart",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cart_ClientId",
                table: "Cart",
                column: "ClientId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_Clients_ClientId",
                table: "Cart",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart_Clients_ClientId",
                table: "Cart");

            migrationBuilder.DropIndex(
                name: "IX_Cart_ClientId",
                table: "Cart");

            migrationBuilder.AlterColumn<int>(
                name: "ClientId",
                table: "Cart",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_ClientId",
                table: "Cart",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_Clients_ClientId",
                table: "Cart",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
