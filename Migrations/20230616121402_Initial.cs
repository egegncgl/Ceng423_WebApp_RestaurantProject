using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ceng423_WebApp_RestaurantProject.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {//this code will send to the database
            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    RestaurantID = table.Column<int>(type: "int", nullable: false),
                    MenuID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Restaurant",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    restaurantName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    restaurantDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    restaurantScores = table.Column<int>(type: "int", nullable: false),
                    restaurantVoteCounter = table.Column<int>(type: "int", nullable: false),
                    restaurantRate = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {//dropping the table menu and Restaurant if already exist
            migrationBuilder.DropTable(
                name: "Menus");

            migrationBuilder.DropTable(
                name: "Restaurant");
        }
    }
}
