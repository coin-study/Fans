using Microsoft.EntityFrameworkCore.Migrations;

namespace fans.Data.Migrations
{
    public partial class Modify_IdolEntityModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EnglishName",
                table: "Idols",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EnglishName",
                table: "Idols");
        }
    }
}
