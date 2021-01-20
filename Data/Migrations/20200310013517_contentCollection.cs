using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ImageAfricaProject.Data.Migrations
{
    public partial class contentCollection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_ImageTag_Images_ImageId",
            //    table: "ImageTag");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_ImageTag_Tags_TagId",
            //    table: "ImageTag");

            //migrationBuilder.DropPrimaryKey(
            //    name: "PK_ImageTag",
            //    table: "ImageTag");

            //migrationBuilder.RenameTable(
            //    name: "ImageTag",
            //    newName: "ImageTags");

            //migrationBuilder.RenameIndex(
            //    name: "IX_ImageTag_TagId",
            //    table: "ImageTags",
            //    newName: "IX_ImageTags_TagId");

            //migrationBuilder.RenameIndex(
            //    name: "IX_ImageTag_ImageId",
            //    table: "ImageTags",
            //    newName: "IX_ImageTags_ImageId");

            //migrationBuilder.AddPrimaryKey(
            //    name: "PK_ImageTags",
            //    table: "ImageTags",
            //    column: "Id");

            migrationBuilder.CreateTable(
                name: "ContentCollections",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    CreatorUserId = table.Column<string>(nullable: true),
                    ImageId = table.Column<int>(nullable: false),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    DeleterUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentCollections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContentCollections_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContentCollections_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContentCollections_ImageId",
                table: "ContentCollections",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_ContentCollections_UserId",
                table: "ContentCollections",
                column: "UserId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_ImageTags_Images_ImageId",
            //    table: "ImageTags",
            //    column: "ImageId",
            //    principalTable: "Images",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_ImageTags_Tags_TagId",
            //    table: "ImageTags",
            //    column: "TagId",
            //    principalTable: "Tags",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_ImageTags_Images_ImageId",
            //    table: "ImageTags");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_ImageTags_Tags_TagId",
            //    table: "ImageTags");

            migrationBuilder.DropTable(
                name: "ContentCollections");

            //migrationBuilder.DropPrimaryKey(
            //    name: "PK_ImageTags",
            //    table: "ImageTags");

            //migrationBuilder.RenameTable(
            //    name: "ImageTags",
            //    newName: "ImageTag");

            //migrationBuilder.RenameIndex(
            //    name: "IX_ImageTags_TagId",
            //    table: "ImageTag",
            //    newName: "IX_ImageTag_TagId");

            //migrationBuilder.RenameIndex(
            //    name: "IX_ImageTags_ImageId",
            //    table: "ImageTag",
            //    newName: "IX_ImageTag_ImageId");

            //migrationBuilder.AddPrimaryKey(
            //    name: "PK_ImageTag",
            //    table: "ImageTag",
            //    column: "Id");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_ImageTag_Images_ImageId",
            //    table: "ImageTag",
            //    column: "ImageId",
            //    principalTable: "Images",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_ImageTag_Tags_TagId",
            //    table: "ImageTag",
            //    column: "TagId",
            //    principalTable: "Tags",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);
        }
    }
}
