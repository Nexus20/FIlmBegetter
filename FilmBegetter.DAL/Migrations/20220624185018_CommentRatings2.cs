using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmBegetter.DAL.Migrations
{
    public partial class CommentRatings2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommentRatingUsers_AspNetUsers_UserId",
                table: "CommentRatingUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_CommentRatingUsers_Comments_CommentId",
                table: "CommentRatingUsers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "48eb8d4f-d522-4b6f-9243-5f5392864d1f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5d40a182-0b55-4324-85dd-690eb8e7a424");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "faa7b917-c135-4a19-b9a7-bd052437e957");

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "07c8dba5-8b29-43fa-a5c8-31558ca9729a");

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "4ac711f6-ec00-45c8-9dcf-b73aa4113726");

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "6802d0cc-0f6c-4623-9c83-38a4679584fd");

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "93f927ac-4732-4ebc-ad2e-58f21b572027");

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "9c26a52c-bd94-4dde-8cd7-20de2e7e3ce6");

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "bd8c2aaf-39db-4d2b-848f-c1ce554214ad");

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "e4d70c80-d1db-4be9-9ece-67d191b0fd55");

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "f8dd43d2-d216-4e08-b79b-96982d8b90f0");

            migrationBuilder.DeleteData(
                table: "Subscriptions",
                keyColumn: "Id",
                keyValue: "1919fa93-d990-4d55-bb81-3c45c35be1dd");

            migrationBuilder.DeleteData(
                table: "Subscriptions",
                keyColumn: "Id",
                keyValue: "89dfbeb0-2fb8-45bc-a1e0-9b63813aadbe");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6c59688a-6a0d-410d-8d70-8c890784adba", "e23e5154-968b-417f-9811-e513c14cc4a5", "Admin", "ADMIN" },
                    { "7dc24344-10dc-4638-9528-bd49ce63fdab", "1afb22bb-ae3d-446d-bf5d-0e0531fe8351", "User", "USER" },
                    { "a21a429b-6d9f-4ea0-a72d-fcaf7ebcba43", "e2ccab76-ce2a-4d69-a6b1-6130cb48a9ef", "Moderator", "MODERATOR" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "22ef6192-a74f-4350-a240-a7231223726d", "Drama" },
                    { "5543c3a1-ab7d-494c-9a23-27e39202f904", "Action" },
                    { "695e7b4b-71bc-4379-9a34-aac7e037d226", "Thriller" },
                    { "7e0de72b-af1b-4cf4-a5c0-1397d380e499", "Fantasy" },
                    { "7e843f00-16d8-4c7e-afca-b5d3e11ff12d", "Mystery" },
                    { "bf528eee-70a5-401f-a937-2e9e76dbaa27", "Horror" },
                    { "dd6fa15e-6627-4645-b97d-5f19ab07a404", "Comedy" },
                    { "f1dd79ee-61a1-4b3e-9878-d02fc513d225", "Romance" }
                });

            migrationBuilder.InsertData(
                table: "Subscriptions",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { "2c996788-21e6-4cdd-8f2c-c9256225a5b7", "Basic" },
                    { "9c8c1d9f-7c5d-469b-9228-89df83ce8e78", "Premium" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_CommentRatingUsers_AspNetUsers_UserId",
                table: "CommentRatingUsers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CommentRatingUsers_Comments_CommentId",
                table: "CommentRatingUsers",
                column: "CommentId",
                principalTable: "Comments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommentRatingUsers_AspNetUsers_UserId",
                table: "CommentRatingUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_CommentRatingUsers_Comments_CommentId",
                table: "CommentRatingUsers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6c59688a-6a0d-410d-8d70-8c890784adba");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7dc24344-10dc-4638-9528-bd49ce63fdab");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a21a429b-6d9f-4ea0-a72d-fcaf7ebcba43");

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "22ef6192-a74f-4350-a240-a7231223726d");

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "5543c3a1-ab7d-494c-9a23-27e39202f904");

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "695e7b4b-71bc-4379-9a34-aac7e037d226");

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "7e0de72b-af1b-4cf4-a5c0-1397d380e499");

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "7e843f00-16d8-4c7e-afca-b5d3e11ff12d");

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "bf528eee-70a5-401f-a937-2e9e76dbaa27");

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "dd6fa15e-6627-4645-b97d-5f19ab07a404");

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "f1dd79ee-61a1-4b3e-9878-d02fc513d225");

            migrationBuilder.DeleteData(
                table: "Subscriptions",
                keyColumn: "Id",
                keyValue: "2c996788-21e6-4cdd-8f2c-c9256225a5b7");

            migrationBuilder.DeleteData(
                table: "Subscriptions",
                keyColumn: "Id",
                keyValue: "9c8c1d9f-7c5d-469b-9228-89df83ce8e78");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "48eb8d4f-d522-4b6f-9243-5f5392864d1f", "e027721b-80b6-4387-9450-77278a569afb", "User", "USER" },
                    { "5d40a182-0b55-4324-85dd-690eb8e7a424", "6a0108ac-bde1-41df-a129-7d7ee6efc1f3", "Admin", "ADMIN" },
                    { "faa7b917-c135-4a19-b9a7-bd052437e957", "eb608064-84d9-49e6-81d0-e9c4f3661b95", "Moderator", "MODERATOR" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "CreationDate", "Name" },
                values: new object[,]
                {
                    { "07c8dba5-8b29-43fa-a5c8-31558ca9729a", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Romance" },
                    { "4ac711f6-ec00-45c8-9dcf-b73aa4113726", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Horror" },
                    { "6802d0cc-0f6c-4623-9c83-38a4679584fd", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fantasy" },
                    { "93f927ac-4732-4ebc-ad2e-58f21b572027", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mystery" },
                    { "9c26a52c-bd94-4dde-8cd7-20de2e7e3ce6", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Comedy" },
                    { "bd8c2aaf-39db-4d2b-848f-c1ce554214ad", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thriller" },
                    { "e4d70c80-d1db-4be9-9ece-67d191b0fd55", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Drama" },
                    { "f8dd43d2-d216-4e08-b79b-96982d8b90f0", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Action" }
                });

            migrationBuilder.InsertData(
                table: "Subscriptions",
                columns: new[] { "Id", "CreationDate", "Type" },
                values: new object[,]
                {
                    { "1919fa93-d990-4d55-bb81-3c45c35be1dd", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Premium" },
                    { "89dfbeb0-2fb8-45bc-a1e0-9b63813aadbe", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Basic" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_CommentRatingUsers_AspNetUsers_UserId",
                table: "CommentRatingUsers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CommentRatingUsers_Comments_CommentId",
                table: "CommentRatingUsers",
                column: "CommentId",
                principalTable: "Comments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
