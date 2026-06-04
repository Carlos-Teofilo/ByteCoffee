using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CatalogContext.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "quantity",
                table: "product",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddCheckConstraint(
                name: "CK_product_quantity_greater_or_equal_than_zero",
                table: "product",
                sql: "quantity > 0");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_product_quantity_greater_or_equal_than_zero",
                table: "product");

            migrationBuilder.DropColumn(
                name: "quantity",
                table: "product");
        }
    }
}
