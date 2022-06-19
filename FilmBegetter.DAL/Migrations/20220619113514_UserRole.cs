using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmBegetter.DAL.Migrations
{
    public partial class UserRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "305b05d9-e4c1-4538-a8ea-118a7a0099a7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7b3d1c99-617a-41a2-bf84-abfe5fd100a7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c1f12ce1-d6ea-43d5-9c7a-6ac647ac5e83");

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "36bd3863-70b2-4e22-9a75-ea562b30a5f9");

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "4a45cebc-4296-45a9-8910-85d68ddc403c");

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "53775d3b-8603-4fcd-b380-68682e1ea9a7");

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "660cf41e-e0ca-42c5-9069-b5c544e2ff6e");

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "90eed977-8a02-498d-91d4-8da4404b63af");

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "a4deec5d-fd8f-4ef3-9c27-f23b04c37f70");

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "d715ff1e-8247-4659-acb3-53624028774b");

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "e60917ab-790f-4843-a616-3bdb16d37c0c");

            migrationBuilder.DeleteData(
                table: "Subscriptions",
                keyColumn: "Id",
                keyValue: "280e1e4b-d91d-4d39-b459-c4cc802dfade");

            migrationBuilder.DeleteData(
                table: "Subscriptions",
                keyColumn: "Id",
                keyValue: "9cd7ca57-8acd-4b6f-a8dd-687af711d9ba");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7de42ce8-ba5e-44df-b076-d1bca9a7bb33", "3a950575-68c8-4d79-943e-c1b81736e370", "Admin", null },
                    { "8f686479-0a02-49c7-8fd5-070653a6f905", "fa1cf1f0-4131-4da2-be57-3cfcabc529c8", "Moderator", null },
                    { "c3a86a06-6812-41ed-9cb5-e16451889b47", "65baef58-be2a-4f1a-a1ba-a7492df13f12", "User", null }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "23030e11-41f5-42ff-a207-ac6f064a20b8", "Drama" },
                    { "2e5921cc-c2bc-4a09-9ecf-0c7ad3da0781", "Mystery" },
                    { "3513fa17-dd57-466d-9b3f-f67996a27e55", "Romance" },
                    { "476d1223-ca3c-441a-9df1-1a3dbf18bc58", "Comedy" },
                    { "5e2727e0-07e3-4f5b-84e4-7f37889e5017", "Action" },
                    { "64195b42-39de-4b18-8ba2-e88762ba22bb", "Horror" },
                    { "7c0abffe-968c-489b-a961-504bcf4117f0", "Fantasy" },
                    { "ef720eb3-4fe7-4e2d-8ddb-8426b6cccf3e", "Thriller" }
                });

            migrationBuilder.InsertData(
                table: "Subscriptions",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { "0e35ae6f-f5fc-4af8-a094-9550fcfb05f4", "Basic" },
                    { "e46f5884-4a65-45e7-bc5e-d011e677beff", "Premium" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7de42ce8-ba5e-44df-b076-d1bca9a7bb33");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8f686479-0a02-49c7-8fd5-070653a6f905");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c3a86a06-6812-41ed-9cb5-e16451889b47");

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "23030e11-41f5-42ff-a207-ac6f064a20b8");

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "2e5921cc-c2bc-4a09-9ecf-0c7ad3da0781");

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "3513fa17-dd57-466d-9b3f-f67996a27e55");

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "476d1223-ca3c-441a-9df1-1a3dbf18bc58");

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "5e2727e0-07e3-4f5b-84e4-7f37889e5017");

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "64195b42-39de-4b18-8ba2-e88762ba22bb");

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "7c0abffe-968c-489b-a961-504bcf4117f0");

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "ef720eb3-4fe7-4e2d-8ddb-8426b6cccf3e");

            migrationBuilder.DeleteData(
                table: "Subscriptions",
                keyColumn: "Id",
                keyValue: "0e35ae6f-f5fc-4af8-a094-9550fcfb05f4");

            migrationBuilder.DeleteData(
                table: "Subscriptions",
                keyColumn: "Id",
                keyValue: "e46f5884-4a65-45e7-bc5e-d011e677beff");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "305b05d9-e4c1-4538-a8ea-118a7a0099a7", "b622f267-7543-4e1d-a35e-6dbc87f42161", "Moderator", null },
                    { "7b3d1c99-617a-41a2-bf84-abfe5fd100a7", "cb95ab60-b064-4f6a-8bce-11ad796caead", "Admin", null },
                    { "c1f12ce1-d6ea-43d5-9c7a-6ac647ac5e83", "8ec0b918-30e9-47bf-9265-1ad5529ef07c", "User", null }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "CreationDate", "Name" },
                values: new object[,]
                {
                    { "36bd3863-70b2-4e22-9a75-ea562b30a5f9", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Horror" },
                    { "4a45cebc-4296-45a9-8910-85d68ddc403c", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Action" },
                    { "53775d3b-8603-4fcd-b380-68682e1ea9a7", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Romance" },
                    { "660cf41e-e0ca-42c5-9069-b5c544e2ff6e", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Drama" },
                    { "90eed977-8a02-498d-91d4-8da4404b63af", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fantasy" },
                    { "a4deec5d-fd8f-4ef3-9c27-f23b04c37f70", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Comedy" },
                    { "d715ff1e-8247-4659-acb3-53624028774b", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mystery" },
                    { "e60917ab-790f-4843-a616-3bdb16d37c0c", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thriller" }
                });

            migrationBuilder.InsertData(
                table: "Subscriptions",
                columns: new[] { "Id", "CreationDate", "Type" },
                values: new object[,]
                {
                    { "280e1e4b-d91d-4d39-b459-c4cc802dfade", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Basic" },
                    { "9cd7ca57-8acd-4b6f-a8dd-687af711d9ba", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Premium" }
                });
        }
    }
}
