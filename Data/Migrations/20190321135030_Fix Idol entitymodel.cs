using Microsoft.EntityFrameworkCore.Migrations;

namespace fans.Data.Migrations
{
    public partial class FixIdolentitymodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Favourite",
                table: "Members");

            migrationBuilder.AddColumn<int>(
                name: "FavouriteId",
                table: "Members",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Members_FavouriteId",
                table: "Members",
                column: "FavouriteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Members_Idols_FavouriteId",
                table: "Members",
                column: "FavouriteId",
                principalTable: "Idols",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Members_Idols_FavouriteId",
                table: "Members");

            migrationBuilder.DropIndex(
                name: "IX_Members_FavouriteId",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "FavouriteId",
                table: "Members");

            migrationBuilder.AddColumn<string>(
                name: "Favourite",
                table: "Members",
                nullable: true);
        }
    }
}
