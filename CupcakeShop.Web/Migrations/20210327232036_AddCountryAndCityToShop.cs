using Microsoft.EntityFrameworkCore.Migrations;

namespace CupcakeShop.Web.Migrations
{
    public partial class AddCountryAndCityToShop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Shops",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Shops",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Shops");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Shops");
        }
    }
}
