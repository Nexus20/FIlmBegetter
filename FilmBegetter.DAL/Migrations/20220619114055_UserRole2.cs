using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmBegetter.DAL.Migrations
{
    public partial class UserRole2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "01386fc1-da90-4ed4-826e-55c761202154", "2e7f0e97-85b7-48dd-ab85-ffd020ed9078", "Admin", null },
                    { "31e07e67-9fef-472d-b3c6-dd73cda30493", "a122a7f4-7570-4c8d-a9db-6f4ea73fe2d9", "User", null },
                    { "5e2cc779-0613-4761-8e5a-9d456d29e3cc", "1a402cdb-6efc-4c0d-8fc4-a8ceefe7dc80", "Moderator", null }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "0b48dc44-2ce5-4c65-bff4-6c221c668bdb", "Action" },
                    { "53fd25f4-897c-45ca-8586-5e9979c1ec1c", "Drama" },
                    { "5baef42e-9ea5-4699-8bf2-2686d9376f97", "Mystery" },
                    { "764b803a-0ee6-4516-b9b4-a1bfe44cddf6", "Thriller" },
                    { "839c6bf5-af28-45e0-b7c7-2c06f90797e9", "Comedy" },
                    { "b5fa8b03-d210-49ad-9607-814ef2840340", "Horror" },
                    { "b8b712b4-cdc4-4f28-8050-033814937882", "Fantasy" },
                    { "f59cc55e-cec9-4ba2-9778-c446f44f5f15", "Romance" }
                });

            migrationBuilder.InsertData(
                table: "Subscriptions",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { "2f8a3dea-b660-40ba-9552-a257e398d0b0", "Basic" },
                    { "9bbaf9e8-d031-4b85-9dea-3608d1b0caf6", "Premium" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01386fc1-da90-4ed4-826e-55c761202154");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "31e07e67-9fef-472d-b3c6-dd73cda30493");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5e2cc779-0613-4761-8e5a-9d456d29e3cc");

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "0b48dc44-2ce5-4c65-bff4-6c221c668bdb");

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "53fd25f4-897c-45ca-8586-5e9979c1ec1c");

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "5baef42e-9ea5-4699-8bf2-2686d9376f97");

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "764b803a-0ee6-4516-b9b4-a1bfe44cddf6");

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "839c6bf5-af28-45e0-b7c7-2c06f90797e9");

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "b5fa8b03-d210-49ad-9607-814ef2840340");

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "b8b712b4-cdc4-4f28-8050-033814937882");

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "f59cc55e-cec9-4ba2-9778-c446f44f5f15");

            migrationBuilder.DeleteData(
                table: "Subscriptions",
                keyColumn: "Id",
                keyValue: "2f8a3dea-b660-40ba-9552-a257e398d0b0");

            migrationBuilder.DeleteData(
                table: "Subscriptions",
                keyColumn: "Id",
                keyValue: "9bbaf9e8-d031-4b85-9dea-3608d1b0caf6");

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
                columns: new[] { "Id", "CreationDate", "Name" },
                values: new object[,]
                {
                    { "23030e11-41f5-42ff-a207-ac6f064a20b8", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Drama" },
                    { "2e5921cc-c2bc-4a09-9ecf-0c7ad3da0781", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mystery" },
                    { "3513fa17-dd57-466d-9b3f-f67996a27e55", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Romance" },
                    { "476d1223-ca3c-441a-9df1-1a3dbf18bc58", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Comedy" },
                    { "5e2727e0-07e3-4f5b-84e4-7f37889e5017", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Action" },
                    { "64195b42-39de-4b18-8ba2-e88762ba22bb", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Horror" },
                    { "7c0abffe-968c-489b-a961-504bcf4117f0", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fantasy" },
                    { "ef720eb3-4fe7-4e2d-8ddb-8426b6cccf3e", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thriller" }
                });

            migrationBuilder.InsertData(
                table: "Subscriptions",
                columns: new[] { "Id", "CreationDate", "Type" },
                values: new object[,]
                {
                    { "0e35ae6f-f5fc-4af8-a094-9550fcfb05f4", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Basic" },
                    { "e46f5884-4a65-45e7-bc5e-d011e677beff", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Premium" }
                });
        }
    }
}
