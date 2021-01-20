using Microsoft.EntityFrameworkCore.Migrations;

namespace ImageAfricaProject.Data.Migrations
{
    public partial class removeIsVideoproperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsVideo",
                table: "Images");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsVideo",
                table: "Images",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
