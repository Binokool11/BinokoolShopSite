using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BinokoolShop.Migrations
{
    public partial class _initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "guitars",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LongText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsAvaible = table.Column<bool>(type: "bit", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    Img = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_guitars", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "guitars",
                columns: new[] { "Id", "Count", "Img", "IsAvaible", "LongText", "Name", "Price", "ShortText" },
                values: new object[] { new Guid("75db221d-d327-45a8-9107-c56984b8b710"), 10, "~/img/Gibson.jpg", true, "Очень крутая гитара", "Gibson", 99.9m, "Крутая гитара" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "guitars");
        }
    }
}
