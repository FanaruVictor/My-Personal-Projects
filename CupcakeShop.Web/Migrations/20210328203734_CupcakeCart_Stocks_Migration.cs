using Microsoft.EntityFrameworkCore.Migrations;

namespace CupcakeShop.Web.Migrations
{
    public partial class CupcakeCart_Stocks_Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Cantity",
                table: "OrderCupcakes",
                newName: "Quantity");

            migrationBuilder.AddColumn<int>(
                name: "Stock",
                table: "Cupcakes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cart_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CupcakeCarts",
                columns: table => new
                {
                    CupcakeId = table.Column<int>(type: "int", nullable: false),
                    CartId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CupcakeCarts", x => new { x.CupcakeId, x.CartId });
                    table.ForeignKey(
                        name: "FK_CupcakeCarts_Cart_CartId",
                        column: x => x.CartId,
                        principalTable: "Cart",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CupcakeCarts_Cupcakes_CupcakeId",
                        column: x => x.CupcakeId,
                        principalTable: "Cupcakes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cart_ClientId",
                table: "Cart",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_CupcakeCarts_CartId",
                table: "CupcakeCarts",
                column: "CartId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CupcakeCarts");

            migrationBuilder.DropTable(
                name: "Cart");

            migrationBuilder.DropColumn(
                name: "Stock",
                table: "Cupcakes");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "OrderCupcakes",
                newName: "Cantity");
        }
    }
}
