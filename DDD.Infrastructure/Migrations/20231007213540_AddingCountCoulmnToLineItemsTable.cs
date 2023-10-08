using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DDD.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddingCountCoulmnToLineItemsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "LineItem",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Count",
                table: "LineItem");
        }
    }
}
