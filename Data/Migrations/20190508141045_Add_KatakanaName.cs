using Microsoft.EntityFrameworkCore.Migrations;

namespace fans.Data.Migrations
{
    public partial class Add_KatakanaName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "KatakanaFirstName",
                table: "Members",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KatakanaLastName",
                table: "Members",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KatakanaFirstName",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "KatakanaLastName",
                table: "Members");
        }
    }
}
