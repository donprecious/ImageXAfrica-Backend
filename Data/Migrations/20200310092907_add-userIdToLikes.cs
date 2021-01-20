using Microsoft.EntityFrameworkCore.Migrations;

namespace ImageAfricaProject.Data.Migrations
{
    public partial class adduserIdToLikes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "ImageLikes",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ImageLikes_UserId",
                table: "ImageLikes",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ImageLikes_AspNetUsers_UserId",
                table: "ImageLikes",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImageLikes_AspNetUsers_UserId",
                table: "ImageLikes");

            migrationBuilder.DropIndex(
                name: "IX_ImageLikes_UserId",
                table: "ImageLikes");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ImageLikes");
        }
    }
}
