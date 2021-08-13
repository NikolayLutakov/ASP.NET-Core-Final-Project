using Microsoft.EntityFrameworkCore.Migrations;

namespace GlassesStore.Data.Migrations
{
    public partial class LikesIntrodused : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                table: "GlassesRatings");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Rating",
                table: "GlassesRatings",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
