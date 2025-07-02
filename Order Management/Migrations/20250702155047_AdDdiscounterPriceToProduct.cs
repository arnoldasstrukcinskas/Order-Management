using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Order_Management.Migrations
{
    /// <inheritdoc />
    public partial class AdDdiscounterPriceToProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "discountedPrice",
                table: "Products",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "discountedPrice",
                table: "Products");
        }
    }
}
