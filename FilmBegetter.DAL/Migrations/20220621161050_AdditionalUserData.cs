using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmBegetter.DAL.Migrations
{
    public partial class AdditionalUserData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "SubscriptionExpirationDare",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "426093c7-7290-477f-8271-3ecdf990827b", "921e9bbd-3356-4a31-a19d-ec099f64f7e4", "User", "USER" },
                    { "514bc406-e101-482e-bc0a-66296a9d9903", "eccc4f35-a20a-4aae-94d0-24028f548d84", "Moderator", "MODERATOR" },
                    { "885987aa-b724-40f3-b33b-1de2f5d8558b", "f34abfbb-aaa0-4ae6-aaa3-ad4f477ad15e", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "4bfc3a03-2e2a-40e7-b41d-37a31b02fb41", "Thriller" },
                    { "5a7ce7f6-a716-4f7d-8089-a87b24f7ef9d", "Mystery" },
                    { "835dda6e-aba6-4afa-aba4-28b94ab7dc0b", "Romance" },
                    { "903aefb6-bf6f-40fe-a4cc-c443a4cf08b1", "Comedy" },
                    { "9708a973-9d46-40f6-a360-8ea6c5786906", "Horror" },
                    { "c36a5e4b-cba8-49cb-9e79-fd699348b813", "Fantasy" },
                    { "f54439f0-ac54-4690-bf93-f8f23d31e4bb", "Drama" },
                    { "f8291155-66c8-478c-bbdf-9aa99a2800ac", "Action" }
                });

            migrationBuilder.InsertData(
                table: "Subscriptions",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { "b444166e-f5f2-4e38-940e-07e32c60700e", "Premium" },
                    { "cce04694-bf6b-4bb9-8131-6c961c7583ab", "Basic" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "426093c7-7290-477f-8271-3ecdf990827b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "514bc406-e101-482e-bc0a-66296a9d9903");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "885987aa-b724-40f3-b33b-1de2f5d8558b");

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "4bfc3a03-2e2a-40e7-b41d-37a31b02fb41");

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "5a7ce7f6-a716-4f7d-8089-a87b24f7ef9d");

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "835dda6e-aba6-4afa-aba4-28b94ab7dc0b");

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "903aefb6-bf6f-40fe-a4cc-c443a4cf08b1");

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "9708a973-9d46-40f6-a360-8ea6c5786906");

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "c36a5e4b-cba8-49cb-9e79-fd699348b813");

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "f54439f0-ac54-4690-bf93-f8f23d31e4bb");

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "f8291155-66c8-478c-bbdf-9aa99a2800ac");

            migrationBuilder.DeleteData(
                table: "Subscriptions",
                keyColumn: "Id",
                keyValue: "b444166e-f5f2-4e38-940e-07e32c60700e");

            migrationBuilder.DeleteData(
                table: "Subscriptions",
                keyColumn: "Id",
                keyValue: "cce04694-bf6b-4bb9-8131-6c961c7583ab");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SubscriptionExpirationDare",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Surname",
                table: "AspNetUsers");

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
                columns: new[] { "Id", "CreationDate", "Name" },
                values: new object[,]
                {
                    { "02b791d1-712d-48c3-b9f0-c48e1b2cab3d", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Action" },
                    { "2c1ac564-f191-4449-90cb-3c107613da20", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fantasy" },
                    { "4260e720-3fc1-4b53-9c24-b44ddec3ff0b", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Comedy" },
                    { "4663b2f8-0c4e-4285-9a9b-28a104bc9213", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mystery" },
                    { "47e87a18-6a7f-49d6-ba1c-792c56463978", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Romance" },
                    { "9e59d843-df20-415a-af90-9b2083dbb66e", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Horror" },
                    { "bfca2d42-d8a8-44fa-8b8a-1720c0268ce4", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Drama" },
                    { "ede884ea-ff17-4196-b561-ec38dfeae55f", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thriller" }
                });

            migrationBuilder.InsertData(
                table: "Subscriptions",
                columns: new[] { "Id", "CreationDate", "Type" },
                values: new object[,]
                {
                    { "4dc7b828-fccb-435e-9ec6-e93ac6501cea", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Premium" },
                    { "68a3c4c8-f379-4bf0-b0d9-de026c6d1f7f", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Basic" }
                });
        }
    }
}
