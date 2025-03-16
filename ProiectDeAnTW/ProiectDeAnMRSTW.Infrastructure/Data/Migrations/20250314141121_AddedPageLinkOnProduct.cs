using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProiectDeAnTW.Migrations
{
    /// <inheritdoc />
    public partial class AddedPageLinkOnProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProductPageLink",
                table: "Aliment",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductPageLink",
                table: "Aliment");
        }
    }
}
