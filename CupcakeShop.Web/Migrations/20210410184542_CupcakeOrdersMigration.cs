using Microsoft.EntityFrameworkCore.Migrations;

namespace CupcakeShop.Web.Migrations
{
    public partial class CupcakeOrdersMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CupcakesOrder_Cupcakes_CupcakeId",
                table: "CupcakesOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_CupcakesOrder_Orders_OrderId",
                table: "CupcakesOrder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CupcakesOrder",
                table: "CupcakesOrder");

            migrationBuilder.RenameTable(
                name: "CupcakesOrder",
                newName: "CupcakeOrders");

            migrationBuilder.RenameIndex(
                name: "IX_CupcakesOrder_OrderId",
                table: "CupcakeOrders",
                newName: "IX_CupcakeOrders_OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CupcakeOrders",
                table: "CupcakeOrders",
                columns: new[] { "CupcakeId", "OrderId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CupcakeOrders_Cupcakes_CupcakeId",
                table: "CupcakeOrders",
                column: "CupcakeId",
                principalTable: "Cupcakes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CupcakeOrders_Orders_OrderId",
                table: "CupcakeOrders",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CupcakeOrders_Cupcakes_CupcakeId",
                table: "CupcakeOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_CupcakeOrders_Orders_OrderId",
                table: "CupcakeOrders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CupcakeOrders",
                table: "CupcakeOrders");

            migrationBuilder.RenameTable(
                name: "CupcakeOrders",
                newName: "CupcakesOrder");

            migrationBuilder.RenameIndex(
                name: "IX_CupcakeOrders_OrderId",
                table: "CupcakesOrder",
                newName: "IX_CupcakesOrder_OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CupcakesOrder",
                table: "CupcakesOrder",
                columns: new[] { "CupcakeId", "OrderId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CupcakesOrder_Cupcakes_CupcakeId",
                table: "CupcakesOrder",
                column: "CupcakeId",
                principalTable: "Cupcakes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CupcakesOrder_Orders_OrderId",
                table: "CupcakesOrder",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
