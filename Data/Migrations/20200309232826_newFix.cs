using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ImageAfricaProject.Data.Migrations
{
    public partial class newFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_ImageTags_Images_ImageId",
            //    table: "ImageTags");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_ImageTags_Tags_TagId",
            //    table: "ImageTags");

            //migrationBuilder.DropPrimaryKey(
            //    name: "PK_ImageTags",
            //    table: "ImageTags");

            //migrationBuilder.DeleteData(
            //    table: "Categories",
            //    keyColumn: "Id",
            //    keyValue: 4);

            //migrationBuilder.DeleteData(
            //    table: "Categories",
            //    keyColumn: "Id",
            //    keyValue: 5);

            //migrationBuilder.DeleteData(
            //    table: "ImageTags",
            //    keyColumn: "Id",
            //    keyValue: 1);

            //migrationBuilder.DeleteData(
            //    table: "ImageTags",
            //    keyColumn: "Id",
            //    keyValue: 2);

            //migrationBuilder.DeleteData(
            //    table: "ImageTags",
            //    keyColumn: "Id",
            //    keyValue: 3);

            //migrationBuilder.DeleteData(
            //    table: "ImageTags",
            //    keyColumn: "Id",
            //    keyValue: 4);

            //migrationBuilder.DeleteData(
            //    table: "ImageTags",
            //    keyColumn: "Id",
            //    keyValue: 5);

            //migrationBuilder.DeleteData(
            //    table: "ImageTags",
            //    keyColumn: "Id",
            //    keyValue: 6);

            //migrationBuilder.DeleteData(
            //    table: "Images",
            //    keyColumn: "Id",
            //    keyValue: 1);

            //migrationBuilder.DeleteData(
            //    table: "Images",
            //    keyColumn: "Id",
            //    keyValue: 2);

            //migrationBuilder.DeleteData(
            //    table: "Images",
            //    keyColumn: "Id",
            //    keyValue: 3);

            //migrationBuilder.DeleteData(
            //    table: "Tags",
            //    keyColumn: "Id",
            //    keyValue: 1);

            //migrationBuilder.DeleteData(
            //    table: "Tags",
            //    keyColumn: "Id",
            //    keyValue: 2);

            //migrationBuilder.DeleteData(
            //    table: "Tags",
            //    keyColumn: "Id",
            //    keyValue: 3);

            //migrationBuilder.DeleteData(
            //    table: "Tags",
            //    keyColumn: "Id",
            //    keyValue: 4);

            //migrationBuilder.DeleteData(
            //    table: "AspNetUsers",
            //    keyColumn: "Id",
            //    keyValue: "c6e56395-b1e1-494c-8294-8e78d484ff50");

            //migrationBuilder.DeleteData(
            //    table: "Categories",
            //    keyColumn: "Id",
            //    keyValue: 1);

            //migrationBuilder.DeleteData(
            //    table: "Categories",
            //    keyColumn: "Id",
            //    keyValue: 2);

            //migrationBuilder.DeleteData(
            //    table: "Categories",
            //    keyColumn: "Id",
            //    keyValue: 3);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            //migrationBuilder.InsertData(
            //    table: "AspNetUsers",
            //    columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfileImageUrl", "SecurityStamp", "TwoFactorEnabled", "UserName" },
            //    values: new object[] { "c6e56395-b1e1-494c-8294-8e78d484ff50", 0, "d77debd3-d492-407b-899c-efc5ffd3f526", "user@gmail.com", false, null, null, false, null, null, null, "AQAAAAEAACcQAAAAEOY1uQYJNd1omPOBEoyg6qvhjfcz9KGGzFWdu27FfkXakYxF6qwkhwdfeqnx56jo6A==", null, false, null, "66b8f264-e6f0-4fe3-b8cb-fc57da74ba29", false, "user@gmail.com" });

            //migrationBuilder.InsertData(
            //    table: "Categories",
            //    columns: new[] { "Id", "CreationTime", "CreatorUserId", "DeleterUserId", "DeletionTime", "Description", "IsDeleted", "LastModificationTime", "LastModifierUserId", "Name" },
            //    values: new object[,]
            //    {
            //        { 1, new DateTime(2020, 3, 3, 3, 48, 7, 591, DateTimeKind.Utc).AddTicks(1798), "c6e56395-b1e1-494c-8294-8e78d484ff50", null, null, null, false, null, null, "Birthday" },
            //        { 2, new DateTime(2020, 3, 3, 3, 48, 7, 591, DateTimeKind.Utc).AddTicks(4463), "c6e56395-b1e1-494c-8294-8e78d484ff50", null, null, null, false, null, null, "Entertainment" },
            //        { 3, new DateTime(2020, 3, 3, 3, 48, 7, 591, DateTimeKind.Utc).AddTicks(4517), "c6e56395-b1e1-494c-8294-8e78d484ff50", null, null, null, false, null, null, "Celebration" },
            //        { 4, new DateTime(2020, 3, 3, 3, 48, 7, 591, DateTimeKind.Utc).AddTicks(4519), "c6e56395-b1e1-494c-8294-8e78d484ff50", null, null, null, false, null, null, "Wild Life" },
            //        { 5, new DateTime(2020, 3, 3, 3, 48, 7, 591, DateTimeKind.Utc).AddTicks(4521), "c6e56395-b1e1-494c-8294-8e78d484ff50", null, null, null, false, null, null, "Animals" }
            //    });

            //migrationBuilder.InsertData(
            //    table: "Tags",
            //    columns: new[] { "Id", "CreationTime", "CreatorUserId", "DeleterUserId", "DeletionTime", "Description", "IsDeleted", "LastModificationTime", "LastModifierUserId", "Name" },
            //    values: new object[,]
            //    {
            //        { 1, new DateTime(2020, 3, 3, 3, 48, 7, 591, DateTimeKind.Utc).AddTicks(6321), null, null, null, null, false, null, null, "Africa" },
            //        { 2, new DateTime(2020, 3, 3, 3, 48, 7, 591, DateTimeKind.Utc).AddTicks(7033), null, null, null, null, false, null, null, "International" },
            //        { 3, new DateTime(2020, 3, 3, 3, 48, 7, 591, DateTimeKind.Utc).AddTicks(7050), null, null, null, null, false, null, null, "Simple" },
            //        { 4, new DateTime(2020, 3, 3, 3, 48, 7, 591, DateTimeKind.Utc).AddTicks(7052), null, null, null, null, false, null, null, "Simple" }
            //    });

            //migrationBuilder.InsertData(
            //    table: "Images",
            //    columns: new[] { "Id", "CategoryId", "CreationTime", "CreatorUserId", "DeleterUserId", "DeletionTime", "Description", "GeoLat", "GeoLog", "ImageUrl", "IsDeleted", "LastModificationTime", "LastModifierUserId", "Location", "Name", "UserId" },
            //    values: new object[] { 1, 1, new DateTime(2020, 3, 3, 3, 48, 7, 591, DateTimeKind.Utc).AddTicks(8418), null, null, null, null, 0.0, 0.0, "https://images.pexels.com/photos/2774197/pexels-photo-2774197.jpeg?auto=compress&cs=tinysrgb&dpr=3&h=750&w=1260", false, null, null, null, "Woman Sitting on a Sofa Chair in a Room", "c6e56395-b1e1-494c-8294-8e78d484ff50" });

            //migrationBuilder.InsertData(
            //    table: "Images",
            //    columns: new[] { "Id", "CategoryId", "CreationTime", "CreatorUserId", "DeleterUserId", "DeletionTime", "Description", "GeoLat", "GeoLog", "ImageUrl", "IsDeleted", "LastModificationTime", "LastModifierUserId", "Location", "Name", "UserId" },
            //    values: new object[] { 2, 2, new DateTime(2020, 3, 3, 3, 48, 7, 592, DateTimeKind.Utc).AddTicks(1052), null, null, null, null, 0.0, 0.0, "https://images.pexels.com/photos/1990360/pexels-photo-1990360.jpeg?auto=compress&cs=tinysrgb&dpr=3&h=750&w=1260", false, null, null, null, "Pretty Woman", "c6e56395-b1e1-494c-8294-8e78d484ff50" });

            //migrationBuilder.InsertData(
            //    table: "Images",
            //    columns: new[] { "Id", "CategoryId", "CreationTime", "CreatorUserId", "DeleterUserId", "DeletionTime", "Description", "GeoLat", "GeoLog", "ImageUrl", "IsDeleted", "LastModificationTime", "LastModifierUserId", "Location", "Name", "UserId" },
            //    values: new object[] { 3, 3, new DateTime(2020, 3, 3, 3, 48, 7, 592, DateTimeKind.Utc).AddTicks(1120), null, null, null, null, 0.0, 0.0, "https://images.pexels.com/photos/3115635/pexels-photo-3115635.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940", false, null, null, null, "Far Lady Woman", "c6e56395-b1e1-494c-8294-8e78d484ff50" });

            //migrationBuilder.InsertData(
            //    table: "ImageTags",
            //    columns: new[] { "Id", "CreationTime", "CreatorUserId", "DeleterUserId", "DeletionTime", "ImageId", "IsDeleted", "LastModificationTime", "LastModifierUserId", "TagId" },
            //    values: new object[,]
            //    {
            //        { 1, new DateTime(2020, 3, 3, 3, 48, 7, 592, DateTimeKind.Utc).AddTicks(2499), null, null, null, 1, false, null, null, 1 },
            //        { 2, new DateTime(2020, 3, 3, 3, 48, 7, 592, DateTimeKind.Utc).AddTicks(3747), null, null, null, 1, false, null, null, 3 },
            //        { 3, new DateTime(2020, 3, 3, 3, 48, 7, 592, DateTimeKind.Utc).AddTicks(3779), null, null, null, 1, false, null, null, 4 },
            //        { 4, new DateTime(2020, 3, 3, 3, 48, 7, 592, DateTimeKind.Utc).AddTicks(3781), null, null, null, 2, false, null, null, 1 },
            //        { 5, new DateTime(2020, 3, 3, 3, 48, 7, 592, DateTimeKind.Utc).AddTicks(3783), null, null, null, 2, false, null, null, 4 },
            //        { 6, new DateTime(2020, 3, 3, 3, 48, 7, 592, DateTimeKind.Utc).AddTicks(3790), null, null, null, 3, false, null, null, 2 }
            //    });

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
    }
}
