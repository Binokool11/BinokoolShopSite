using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BinokoolShop.Migrations
{
    public partial class _three : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "guitars",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "guitars");
        }
    }
}
