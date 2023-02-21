using Microsoft.EntityFrameworkCore.Migrations;

namespace DataaccessLayer.Migrations
{
    public partial class Product_tb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Product_Image = table.Column<string>(nullable: false),
                    Product_Name = table.Column<string>(nullable: false),
                    Product_Description = table.Column<string>(nullable: false),
                    Product_Price = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
