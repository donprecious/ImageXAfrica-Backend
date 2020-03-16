using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ImageAfricaProject.Data.Migrations
{
    public partial class ImagesCategoryImageTag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    CreatorUserId = table.Column<string>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    DeleterUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    CreatorUserId = table.Column<string>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    DeleterUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    GeoLat = table.Column<double>(nullable: false),
                    GeoLog = table.Column<double>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    CreatorUserId = table.Column<string>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    DeleterUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Images_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ImageTags",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    ImageId = table.Column<int>(nullable: false),
                    TagId = table.Column<int>(nullable: false),
                    CreatorUserId = table.Column<string>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    DeleterUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageTags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImageTags_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ImageTags_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfileImageUrl", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "c6e56395-b1e1-494c-8294-8e78d484ff50", 0, "d77debd3-d492-407b-899c-efc5ffd3f526", "user@gmail.com", false, null, null, false, null, null, null, "AQAAAAEAACcQAAAAEOY1uQYJNd1omPOBEoyg6qvhjfcz9KGGzFWdu27FfkXakYxF6qwkhwdfeqnx56jo6A==", null, false, null, "66b8f264-e6f0-4fe3-b8cb-fc57da74ba29", false, "user@gmail.com" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreationTime", "CreatorUserId", "DeleterUserId", "DeletionTime", "Description", "IsDeleted", "LastModificationTime", "LastModifierUserId", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 3, 3, 3, 48, 7, 591, DateTimeKind.Utc).AddTicks(1798), "c6e56395-b1e1-494c-8294-8e78d484ff50", null, null, null, false, null, null, "Birthday" },
                    { 2, new DateTime(2020, 3, 3, 3, 48, 7, 591, DateTimeKind.Utc).AddTicks(4463), "c6e56395-b1e1-494c-8294-8e78d484ff50", null, null, null, false, null, null, "Entertainment" },
                    { 3, new DateTime(2020, 3, 3, 3, 48, 7, 591, DateTimeKind.Utc).AddTicks(4517), "c6e56395-b1e1-494c-8294-8e78d484ff50", null, null, null, false, null, null, "Celebration" },
                    { 4, new DateTime(2020, 3, 3, 3, 48, 7, 591, DateTimeKind.Utc).AddTicks(4519), "c6e56395-b1e1-494c-8294-8e78d484ff50", null, null, null, false, null, null, "Wild Life" },
                    { 5, new DateTime(2020, 3, 3, 3, 48, 7, 591, DateTimeKind.Utc).AddTicks(4521), "c6e56395-b1e1-494c-8294-8e78d484ff50", null, null, null, false, null, null, "Animals" }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "CreationTime", "CreatorUserId", "DeleterUserId", "DeletionTime", "Description", "IsDeleted", "LastModificationTime", "LastModifierUserId", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 3, 3, 3, 48, 7, 591, DateTimeKind.Utc).AddTicks(6321), null, null, null, null, false, null, null, "Africa" },
                    { 2, new DateTime(2020, 3, 3, 3, 48, 7, 591, DateTimeKind.Utc).AddTicks(7033), null, null, null, null, false, null, null, "International" },
                    { 3, new DateTime(2020, 3, 3, 3, 48, 7, 591, DateTimeKind.Utc).AddTicks(7050), null, null, null, null, false, null, null, "Simple" },
                    { 4, new DateTime(2020, 3, 3, 3, 48, 7, 591, DateTimeKind.Utc).AddTicks(7052), null, null, null, null, false, null, null, "Simple" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "CategoryId", "CreationTime", "CreatorUserId", "DeleterUserId", "DeletionTime", "Description", "GeoLat", "GeoLog", "ImageUrl", "IsDeleted", "LastModificationTime", "LastModifierUserId", "Location", "Name", "UserId" },
                values: new object[] { 1, 1, new DateTime(2020, 3, 3, 3, 48, 7, 591, DateTimeKind.Utc).AddTicks(8418), null, null, null, null, 0.0, 0.0, "https://images.pexels.com/photos/2774197/pexels-photo-2774197.jpeg?auto=compress&cs=tinysrgb&dpr=3&h=750&w=1260", false, null, null, null, "Woman Sitting on a Sofa Chair in a Room", "c6e56395-b1e1-494c-8294-8e78d484ff50" });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "CategoryId", "CreationTime", "CreatorUserId", "DeleterUserId", "DeletionTime", "Description", "GeoLat", "GeoLog", "ImageUrl", "IsDeleted", "LastModificationTime", "LastModifierUserId", "Location", "Name", "UserId" },
                values: new object[] { 2, 2, new DateTime(2020, 3, 3, 3, 48, 7, 592, DateTimeKind.Utc).AddTicks(1052), null, null, null, null, 0.0, 0.0, "https://images.pexels.com/photos/1990360/pexels-photo-1990360.jpeg?auto=compress&cs=tinysrgb&dpr=3&h=750&w=1260", false, null, null, null, "Pretty Woman", "c6e56395-b1e1-494c-8294-8e78d484ff50" });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "CategoryId", "CreationTime", "CreatorUserId", "DeleterUserId", "DeletionTime", "Description", "GeoLat", "GeoLog", "ImageUrl", "IsDeleted", "LastModificationTime", "LastModifierUserId", "Location", "Name", "UserId" },
                values: new object[] { 3, 3, new DateTime(2020, 3, 3, 3, 48, 7, 592, DateTimeKind.Utc).AddTicks(1120), null, null, null, null, 0.0, 0.0, "https://images.pexels.com/photos/3115635/pexels-photo-3115635.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940", false, null, null, null, "Far Lady Woman", "c6e56395-b1e1-494c-8294-8e78d484ff50" });

            migrationBuilder.InsertData(
                table: "ImageTags",
                columns: new[] { "Id", "CreationTime", "CreatorUserId", "DeleterUserId", "DeletionTime", "ImageId", "IsDeleted", "LastModificationTime", "LastModifierUserId", "TagId" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 3, 3, 3, 48, 7, 592, DateTimeKind.Utc).AddTicks(2499), null, null, null, 1, false, null, null, 1 },
                    { 2, new DateTime(2020, 3, 3, 3, 48, 7, 592, DateTimeKind.Utc).AddTicks(3747), null, null, null, 1, false, null, null, 3 },
                    { 3, new DateTime(2020, 3, 3, 3, 48, 7, 592, DateTimeKind.Utc).AddTicks(3779), null, null, null, 1, false, null, null, 4 },
                    { 4, new DateTime(2020, 3, 3, 3, 48, 7, 592, DateTimeKind.Utc).AddTicks(3781), null, null, null, 2, false, null, null, 1 },
                    { 5, new DateTime(2020, 3, 3, 3, 48, 7, 592, DateTimeKind.Utc).AddTicks(3783), null, null, null, 2, false, null, null, 4 },
                    { 6, new DateTime(2020, 3, 3, 3, 48, 7, 592, DateTimeKind.Utc).AddTicks(3790), null, null, null, 3, false, null, null, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Images_CategoryId",
                table: "Images",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_UserId",
                table: "Images",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageTags_ImageId",
                table: "ImageTags",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageTags_TagId",
                table: "ImageTags",
                column: "TagId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImageTags");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c6e56395-b1e1-494c-8294-8e78d484ff50");
        }
    }
}
