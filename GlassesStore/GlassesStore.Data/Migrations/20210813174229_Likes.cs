using Microsoft.EntityFrameworkCore.Migrations;

namespace GlassesStore.Data.Migrations
{
    public partial class Likes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GlassesRatings_AspNetUsers_UserId",
                table: "GlassesRatings");

            migrationBuilder.DropForeignKey(
                name: "FK_GlassesRatings_Glasses_GlassesId",
                table: "GlassesRatings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GlassesRatings",
                table: "GlassesRatings");

            migrationBuilder.RenameTable(
                name: "GlassesRatings",
                newName: "GlassesLikes");

            migrationBuilder.RenameIndex(
                name: "IX_GlassesRatings_GlassesId",
                table: "GlassesLikes",
                newName: "IX_GlassesLikes_GlassesId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GlassesLikes",
                table: "GlassesLikes",
                columns: new[] { "UserId", "GlassesId" });

            migrationBuilder.AddForeignKey(
                name: "FK_GlassesLikes_AspNetUsers_UserId",
                table: "GlassesLikes",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GlassesLikes_Glasses_GlassesId",
                table: "GlassesLikes",
                column: "GlassesId",
                principalTable: "Glasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GlassesLikes_AspNetUsers_UserId",
                table: "GlassesLikes");

            migrationBuilder.DropForeignKey(
                name: "FK_GlassesLikes_Glasses_GlassesId",
                table: "GlassesLikes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GlassesLikes",
                table: "GlassesLikes");

            migrationBuilder.RenameTable(
                name: "GlassesLikes",
                newName: "GlassesRatings");

            migrationBuilder.RenameIndex(
                name: "IX_GlassesLikes_GlassesId",
                table: "GlassesRatings",
                newName: "IX_GlassesRatings_GlassesId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GlassesRatings",
                table: "GlassesRatings",
                columns: new[] { "UserId", "GlassesId" });

            migrationBuilder.AddForeignKey(
                name: "FK_GlassesRatings_AspNetUsers_UserId",
                table: "GlassesRatings",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GlassesRatings_Glasses_GlassesId",
                table: "GlassesRatings",
                column: "GlassesId",
                principalTable: "Glasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
