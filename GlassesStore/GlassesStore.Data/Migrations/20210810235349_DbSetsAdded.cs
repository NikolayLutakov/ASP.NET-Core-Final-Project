using Microsoft.EntityFrameworkCore.Migrations;

namespace GlassesStore.Data.Migrations
{
    public partial class DbSetsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Card_AspNetUsers_UserId",
                table: "Card");

            migrationBuilder.DropForeignKey(
                name: "FK_Card_CardType_TypeId",
                table: "Card");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_AspNetUsers_UserId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Glasses_GlassesId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Glasses_Brand_BrandId",
                table: "Glasses");

            migrationBuilder.DropForeignKey(
                name: "FK_Glasses_GlassesType_TypeId",
                table: "Glasses");

            migrationBuilder.DropForeignKey(
                name: "FK_GlassesRating_AspNetUsers_UserId",
                table: "GlassesRating");

            migrationBuilder.DropForeignKey(
                name: "FK_GlassesRating_Glasses_GlassesId",
                table: "GlassesRating");

            migrationBuilder.DropForeignKey(
                name: "FK_Purchase_Card_CardId",
                table: "Purchase");

            migrationBuilder.DropForeignKey(
                name: "FK_Purchase_Glasses_GlassesId",
                table: "Purchase");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Purchase",
                table: "Purchase");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GlassesType",
                table: "GlassesType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GlassesRating",
                table: "GlassesRating");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comment",
                table: "Comment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CardType",
                table: "CardType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Card",
                table: "Card");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Brand",
                table: "Brand");

            migrationBuilder.RenameTable(
                name: "Purchase",
                newName: "Purchases");

            migrationBuilder.RenameTable(
                name: "GlassesType",
                newName: "GlassesTypes");

            migrationBuilder.RenameTable(
                name: "GlassesRating",
                newName: "GlassesRatings");

            migrationBuilder.RenameTable(
                name: "Comment",
                newName: "Comments");

            migrationBuilder.RenameTable(
                name: "CardType",
                newName: "CardTypes");

            migrationBuilder.RenameTable(
                name: "Card",
                newName: "Cards");

            migrationBuilder.RenameTable(
                name: "Brand",
                newName: "Brands");

            migrationBuilder.RenameIndex(
                name: "IX_Purchase_GlassesId",
                table: "Purchases",
                newName: "IX_Purchases_GlassesId");

            migrationBuilder.RenameIndex(
                name: "IX_Purchase_CardId",
                table: "Purchases",
                newName: "IX_Purchases_CardId");

            migrationBuilder.RenameIndex(
                name: "IX_GlassesRating_GlassesId",
                table: "GlassesRatings",
                newName: "IX_GlassesRatings_GlassesId");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_UserId",
                table: "Comments",
                newName: "IX_Comments_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_GlassesId",
                table: "Comments",
                newName: "IX_Comments_GlassesId");

            migrationBuilder.RenameIndex(
                name: "IX_Card_UserId",
                table: "Cards",
                newName: "IX_Cards_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Card_TypeId",
                table: "Cards",
                newName: "IX_Cards_TypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Purchases",
                table: "Purchases",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GlassesTypes",
                table: "GlassesTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GlassesRatings",
                table: "GlassesRatings",
                columns: new[] { "UserId", "GlassesId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comments",
                table: "Comments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CardTypes",
                table: "CardTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cards",
                table: "Cards",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Brands",
                table: "Brands",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_AspNetUsers_UserId",
                table: "Cards",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_CardTypes_TypeId",
                table: "Cards",
                column: "TypeId",
                principalTable: "CardTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Glasses_GlassesId",
                table: "Comments",
                column: "GlassesId",
                principalTable: "Glasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Glasses_Brands_BrandId",
                table: "Glasses",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Glasses_GlassesTypes_TypeId",
                table: "Glasses",
                column: "TypeId",
                principalTable: "GlassesTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Purchases_Cards_CardId",
                table: "Purchases",
                column: "CardId",
                principalTable: "Cards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Purchases_Glasses_GlassesId",
                table: "Purchases",
                column: "GlassesId",
                principalTable: "Glasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cards_AspNetUsers_UserId",
                table: "Cards");

            migrationBuilder.DropForeignKey(
                name: "FK_Cards_CardTypes_TypeId",
                table: "Cards");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Glasses_GlassesId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Glasses_Brands_BrandId",
                table: "Glasses");

            migrationBuilder.DropForeignKey(
                name: "FK_Glasses_GlassesTypes_TypeId",
                table: "Glasses");

            migrationBuilder.DropForeignKey(
                name: "FK_GlassesRatings_AspNetUsers_UserId",
                table: "GlassesRatings");

            migrationBuilder.DropForeignKey(
                name: "FK_GlassesRatings_Glasses_GlassesId",
                table: "GlassesRatings");

            migrationBuilder.DropForeignKey(
                name: "FK_Purchases_Cards_CardId",
                table: "Purchases");

            migrationBuilder.DropForeignKey(
                name: "FK_Purchases_Glasses_GlassesId",
                table: "Purchases");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Purchases",
                table: "Purchases");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GlassesTypes",
                table: "GlassesTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GlassesRatings",
                table: "GlassesRatings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comments",
                table: "Comments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CardTypes",
                table: "CardTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cards",
                table: "Cards");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Brands",
                table: "Brands");

            migrationBuilder.RenameTable(
                name: "Purchases",
                newName: "Purchase");

            migrationBuilder.RenameTable(
                name: "GlassesTypes",
                newName: "GlassesType");

            migrationBuilder.RenameTable(
                name: "GlassesRatings",
                newName: "GlassesRating");

            migrationBuilder.RenameTable(
                name: "Comments",
                newName: "Comment");

            migrationBuilder.RenameTable(
                name: "CardTypes",
                newName: "CardType");

            migrationBuilder.RenameTable(
                name: "Cards",
                newName: "Card");

            migrationBuilder.RenameTable(
                name: "Brands",
                newName: "Brand");

            migrationBuilder.RenameIndex(
                name: "IX_Purchases_GlassesId",
                table: "Purchase",
                newName: "IX_Purchase_GlassesId");

            migrationBuilder.RenameIndex(
                name: "IX_Purchases_CardId",
                table: "Purchase",
                newName: "IX_Purchase_CardId");

            migrationBuilder.RenameIndex(
                name: "IX_GlassesRatings_GlassesId",
                table: "GlassesRating",
                newName: "IX_GlassesRating_GlassesId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_UserId",
                table: "Comment",
                newName: "IX_Comment_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_GlassesId",
                table: "Comment",
                newName: "IX_Comment_GlassesId");

            migrationBuilder.RenameIndex(
                name: "IX_Cards_UserId",
                table: "Card",
                newName: "IX_Card_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Cards_TypeId",
                table: "Card",
                newName: "IX_Card_TypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Purchase",
                table: "Purchase",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GlassesType",
                table: "GlassesType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GlassesRating",
                table: "GlassesRating",
                columns: new[] { "UserId", "GlassesId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comment",
                table: "Comment",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CardType",
                table: "CardType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Card",
                table: "Card",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Brand",
                table: "Brand",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Card_AspNetUsers_UserId",
                table: "Card",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Card_CardType_TypeId",
                table: "Card",
                column: "TypeId",
                principalTable: "CardType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_AspNetUsers_UserId",
                table: "Comment",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Glasses_GlassesId",
                table: "Comment",
                column: "GlassesId",
                principalTable: "Glasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Glasses_Brand_BrandId",
                table: "Glasses",
                column: "BrandId",
                principalTable: "Brand",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Glasses_GlassesType_TypeId",
                table: "Glasses",
                column: "TypeId",
                principalTable: "GlassesType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GlassesRating_AspNetUsers_UserId",
                table: "GlassesRating",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GlassesRating_Glasses_GlassesId",
                table: "GlassesRating",
                column: "GlassesId",
                principalTable: "Glasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Purchase_Card_CardId",
                table: "Purchase",
                column: "CardId",
                principalTable: "Card",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Purchase_Glasses_GlassesId",
                table: "Purchase",
                column: "GlassesId",
                principalTable: "Glasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
