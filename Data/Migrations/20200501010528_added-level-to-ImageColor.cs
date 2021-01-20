using Microsoft.EntityFrameworkCore.Migrations;

namespace ImageAfricaProject.Data.Migrations
{
    public partial class addedleveltoImageColor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Level",
                table: "ImageColors",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Level",
                table: "ImageColors");
        }
    }
}
