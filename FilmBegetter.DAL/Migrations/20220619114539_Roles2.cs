using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmBegetter.DAL.Migrations
{
    public partial class Roles2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "108cb068-c39d-4eee-be50-90a33b3c475f", "77b7cf23-0812-4a0b-bd0f-bef853641845", "Moderator", "MODERATOR" },
                    { "88c70a4c-eea5-40e4-a7c9-cec2f6872a38", "c307dad7-aaa1-40fb-82f2-2f496e79de7a", "Admin", "ADMIN" },
                    { "e7e17cdb-1c31-4470-811b-7ff69642a9fe", "3548e679-d5a4-419d-a2e8-b0f8fdedce83", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "02b791d1-712d-48c3-b9f0-c48e1b2cab3d", "Action" },
                    { "2c1ac564-f191-4449-90cb-3c107613da20", "Fantasy" },
                    { "4260e720-3fc1-4b53-9c24-b44ddec3ff0b", "Comedy" },
                    { "4663b2f8-0c4e-4285-9a9b-28a104bc9213", "Mystery" },
                    { "47e87a18-6a7f-49d6-ba1c-792c56463978", "Romance" },
                    { "9e59d843-df20-415a-af90-9b2083dbb66e", "Horror" },
                    { "bfca2d42-d8a8-44fa-8b8a-1720c0268ce4", "Drama" },
                    { "ede884ea-ff17-4196-b561-ec38dfeae55f", "Thriller" }
                });

            migrationBuilder.InsertData(
                table: "Subscriptions",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { "4dc7b828-fccb-435e-9ec6-e93ac6501cea", "Premium" },
                    { "68a3c4c8-f379-4bf0-b0d9-de026c6d1f7f", "Basic" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "108cb068-c39d-4eee-be50-90a33b3c475f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "88c70a4c-eea5-40e4-a7c9-cec2f6872a38");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e7e17cdb-1c31-4470-811b-7ff69642a9fe");

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "02b791d1-712d-48c3-b9f0-c48e1b2cab3d");

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "2c1ac564-f191-4449-90cb-3c107613da20");

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "4260e720-3fc1-4b53-9c24-b44ddec3ff0b");

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "4663b2f8-0c4e-4285-9a9b-28a104bc9213");

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "47e87a18-6a7f-49d6-ba1c-792c56463978");

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "9e59d843-df20-415a-af90-9b2083dbb66e");

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "bfca2d42-d8a8-44fa-8b8a-1720c0268ce4");

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "ede884ea-ff17-4196-b561-ec38dfeae55f");

            migrationBuilder.DeleteData(
                table: "Subscriptions",
                keyColumn: "Id",
                keyValue: "4dc7b828-fccb-435e-9ec6-e93ac6501cea");

            migrationBuilder.DeleteData(
                table: "Subscriptions",
                keyColumn: "Id",
                keyValue: "68a3c4c8-f379-4bf0-b0d9-de026c6d1f7f");

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
                columns: new[] { "Id", "CreationDate", "Name" },
                values: new object[,]
                {
                    { "0b48dc44-2ce5-4c65-bff4-6c221c668bdb", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Action" },
                    { "53fd25f4-897c-45ca-8586-5e9979c1ec1c", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Drama" },
                    { "5baef42e-9ea5-4699-8bf2-2686d9376f97", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mystery" },
                    { "764b803a-0ee6-4516-b9b4-a1bfe44cddf6", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thriller" },
                    { "839c6bf5-af28-45e0-b7c7-2c06f90797e9", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Comedy" },
                    { "b5fa8b03-d210-49ad-9607-814ef2840340", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Horror" },
                    { "b8b712b4-cdc4-4f28-8050-033814937882", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fantasy" },
                    { "f59cc55e-cec9-4ba2-9778-c446f44f5f15", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Romance" }
                });

            migrationBuilder.InsertData(
                table: "Subscriptions",
                columns: new[] { "Id", "CreationDate", "Type" },
                values: new object[,]
                {
                    { "2f8a3dea-b660-40ba-9552-a257e398d0b0", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Basic" },
                    { "9bbaf9e8-d031-4b85-9dea-3608d1b0caf6", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Premium" }
                });
        }
    }
}
