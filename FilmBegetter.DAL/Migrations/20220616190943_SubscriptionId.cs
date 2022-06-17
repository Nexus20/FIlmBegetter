using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmBegetter.DAL.Migrations
{
    public partial class SubscriptionId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "0ae34292-d164-4557-a3d5-69d51c7710e7", "Comedy" },
                    { "321792ea-1ac7-4a3a-a967-14ceb03bef43", "Mystery" },
                    { "6e71f28d-eccd-42b4-8888-6c8cfbe18921", "Romance" },
                    { "7e452c05-641c-4b2d-afc7-f360178ee0a8", "Drama" },
                    { "8f0e80e4-2d14-46d0-a701-527d0270d078", "Horror" },
                    { "9def0dde-1184-42f0-8a8b-5cb53ab0daa6", "Fantasy" },
                    { "b5b275d5-429c-46d9-a0b4-69ae4c6dbf62", "Action" },
                    { "c79ca0be-e642-4085-81d8-fcd2f4d637f4", "Thriller" }
                });

            migrationBuilder.InsertData(
                table: "Subscriptions",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { "28e9b37d-a3a2-4d7f-a7f7-b84e1fcd60f6", "Premium" },
                    { "5df936bd-e181-4b11-9963-5871faff3801", "Basic" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "0ae34292-d164-4557-a3d5-69d51c7710e7");

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "321792ea-1ac7-4a3a-a967-14ceb03bef43");

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "6e71f28d-eccd-42b4-8888-6c8cfbe18921");

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "7e452c05-641c-4b2d-afc7-f360178ee0a8");

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "8f0e80e4-2d14-46d0-a701-527d0270d078");

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "9def0dde-1184-42f0-8a8b-5cb53ab0daa6");

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "b5b275d5-429c-46d9-a0b4-69ae4c6dbf62");

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "c79ca0be-e642-4085-81d8-fcd2f4d637f4");

            migrationBuilder.DeleteData(
                table: "Subscriptions",
                keyColumn: "Id",
                keyValue: "28e9b37d-a3a2-4d7f-a7f7-b84e1fcd60f6");

            migrationBuilder.DeleteData(
                table: "Subscriptions",
                keyColumn: "Id",
                keyValue: "5df936bd-e181-4b11-9963-5871faff3801");

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "CreationDate", "Name" },
                values: new object[,]
                {
                    { "0ecedeed-812c-45f3-9d19-fac89820c203", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mystery" },
                    { "103fcd2a-bed4-4f40-9f87-31d07cc43539", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thriller" },
                    { "431e78bb-74ee-4169-a976-97f06ead6713", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Horror" },
                    { "8746e8bb-ed0c-4283-9f88-f87602e653f6", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fantasy" },
                    { "8ae23b2a-fba4-4e7d-983f-79f78e2b70d7", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Drama" },
                    { "b7383317-5ee5-4b7c-9958-eb10ca87e9b5", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Romance" },
                    { "d14bb929-6046-4b39-ac3e-3d002c1033eb", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Comedy" },
                    { "ff16d4be-29ff-46e8-a62d-a2ae818ca495", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Action" }
                });

            migrationBuilder.InsertData(
                table: "Subscriptions",
                columns: new[] { "Id", "CreationDate", "Type" },
                values: new object[,]
                {
                    { "036c3174-6f33-4515-bc6a-4becef8a5ee9", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Premium" },
                    { "54a9f55f-8576-4127-a455-933a898aa99c", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Basic" }
                });
        }
    }
}
