using Microsoft.EntityFrameworkCore.Migrations;

namespace fans.Data.Migrations
{
    public partial class Modify_Club_EntityModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ChineseName",
                table: "Clubs",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChineseName",
                table: "Clubs");
        }
    }
}
