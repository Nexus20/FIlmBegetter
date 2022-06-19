using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmBegetter.DAL.Migrations
{
    public partial class SubscriptionTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "2853a445-6368-42f3-ae98-6284afe18552");

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "2c2f40c0-ed95-4f50-8c7a-30a23076e772");

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "2c33dba5-3b44-4f75-8895-64764467fc90");

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "65713510-be94-439f-ac56-f3b5242a867d");

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "89843592-a214-4658-97d7-e2dd37b75e74");

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "a6e658d4-d87a-4cc7-80e2-4d19a063e671");

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "bf9db786-18be-420f-916e-ab38557e685a");

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "efab3ed7-83ea-4382-ab06-6d5b50a3a029");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Subscriptions",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "0ecedeed-812c-45f3-9d19-fac89820c203", "Mystery" },
                    { "103fcd2a-bed4-4f40-9f87-31d07cc43539", "Thriller" },
                    { "431e78bb-74ee-4169-a976-97f06ead6713", "Horror" },
                    { "8746e8bb-ed0c-4283-9f88-f87602e653f6", "Fantasy" },
                    { "8ae23b2a-fba4-4e7d-983f-79f78e2b70d7", "Drama" },
                    { "b7383317-5ee5-4b7c-9958-eb10ca87e9b5", "Romance" },
                    { "d14bb929-6046-4b39-ac3e-3d002c1033eb", "Comedy" },
                    { "ff16d4be-29ff-46e8-a62d-a2ae818ca495", "Action" }
                });

            migrationBuilder.InsertData(
                table: "Subscriptions",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { "036c3174-6f33-4515-bc6a-4becef8a5ee9", "Premium" },
                    { "54a9f55f-8576-4127-a455-933a898aa99c", "Basic" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_Type",
                table: "Subscriptions",
                column: "Type",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Subscriptions_Type",
                table: "Subscriptions");

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "0ecedeed-812c-45f3-9d19-fac89820c203");

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "103fcd2a-bed4-4f40-9f87-31d07cc43539");

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "431e78bb-74ee-4169-a976-97f06ead6713");

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "8746e8bb-ed0c-4283-9f88-f87602e653f6");

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "8ae23b2a-fba4-4e7d-983f-79f78e2b70d7");

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "b7383317-5ee5-4b7c-9958-eb10ca87e9b5");

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "d14bb929-6046-4b39-ac3e-3d002c1033eb");

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "ff16d4be-29ff-46e8-a62d-a2ae818ca495");

            migrationBuilder.DeleteData(
                table: "Subscriptions",
                keyColumn: "Id",
                keyValue: "036c3174-6f33-4515-bc6a-4becef8a5ee9");

            migrationBuilder.DeleteData(
                table: "Subscriptions",
                keyColumn: "Id",
                keyValue: "54a9f55f-8576-4127-a455-933a898aa99c");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Subscriptions");

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "CreationDate", "Name" },
                values: new object[,]
                {
                    { "2853a445-6368-42f3-ae98-6284afe18552", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fantasy" },
                    { "2c2f40c0-ed95-4f50-8c7a-30a23076e772", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mystery" },
                    { "2c33dba5-3b44-4f75-8895-64764467fc90", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Action" },
                    { "65713510-be94-439f-ac56-f3b5242a867d", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Horror" },
                    { "89843592-a214-4658-97d7-e2dd37b75e74", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Comedy" },
                    { "a6e658d4-d87a-4cc7-80e2-4d19a063e671", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Drama" },
                    { "bf9db786-18be-420f-916e-ab38557e685a", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thriller" },
                    { "efab3ed7-83ea-4382-ab06-6d5b50a3a029", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Romance" }
                });
        }
    }
}
