using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ETaraba.Infrastructure.Migrations
{
    public partial class AddingFieldsIntoBasketProductModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "BasketProducts",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "BasketProducts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "BasketProducts");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "BasketProducts");
        }
    }
}
