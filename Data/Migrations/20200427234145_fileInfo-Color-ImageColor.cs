using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ImageAfricaProject.Data.Migrations
{
    public partial class fileInfoColorImageColor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatorUserId",
                table: "ImageViews",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeleterUserId",
                table: "ImageViews",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "ImageViews",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ImageViews",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "ImageViews",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifierUserId",
                table: "ImageViews",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatorUserId",
                table: "ImageLikes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeleterUserId",
                table: "ImageLikes",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "ImageLikes",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ImageLikes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "ImageLikes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifierUserId",
                table: "ImageLikes",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Colors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<string>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    DeleterUserId = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FileInfos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<string>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    DeleterUserId = table.Column<string>(nullable: true),
                    ImageId = table.Column<int>(nullable: false),
                    Artist = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    Software = table.Column<string>(nullable: true),
                    Width = table.Column<string>(nullable: true),
                    Height = table.Column<string>(nullable: true),
                    Duration = table.Column<string>(nullable: true),
                    Genre = table.Column<string>(nullable: true),
                    FileSize = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FileInfos_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ImageColors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<string>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    DeleterUserId = table.Column<string>(nullable: true),
                    ImageId = table.Column<int>(nullable: false),
                    ColorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageColors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImageColors_Colors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Colors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ImageColors_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FileInfos_ImageId",
                table: "FileInfos",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageColors_ColorId",
                table: "ImageColors",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageColors_ImageId",
                table: "ImageColors",
                column: "ImageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FileInfos");

            migrationBuilder.DropTable(
                name: "ImageColors");

            migrationBuilder.DropTable(
                name: "Colors");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "ImageViews");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "ImageViews");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "ImageViews");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ImageViews");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "ImageViews");

            migrationBuilder.DropColumn(
                name: "LastModifierUserId",
                table: "ImageViews");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "ImageLikes");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "ImageLikes");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "ImageLikes");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ImageLikes");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "ImageLikes");

            migrationBuilder.DropColumn(
                name: "LastModifierUserId",
                table: "ImageLikes");
        }
    }
}
