using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmBegetter.DAL.Migrations
{
    public partial class CommentRatings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Comments_ParentCommentId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_ParentCommentId",
                table: "Comments");

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
                name: "ParentCommentId",
                table: "Comments");

            migrationBuilder.CreateTable(
                name: "CommentRatingUsers",
                columns: table => new
                {
                    CommentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentRatingUsers", x => new { x.UserId, x.CommentId });
                    table.ForeignKey(
                        name: "FK_CommentRatingUsers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommentRatingUsers_Comments_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "07c8dba5-8b29-43fa-a5c8-31558ca9729a", "Romance" },
                    { "4ac711f6-ec00-45c8-9dcf-b73aa4113726", "Horror" },
                    { "6802d0cc-0f6c-4623-9c83-38a4679584fd", "Fantasy" },
                    { "93f927ac-4732-4ebc-ad2e-58f21b572027", "Mystery" },
                    { "9c26a52c-bd94-4dde-8cd7-20de2e7e3ce6", "Comedy" },
                    { "bd8c2aaf-39db-4d2b-848f-c1ce554214ad", "Thriller" },
                    { "e4d70c80-d1db-4be9-9ece-67d191b0fd55", "Drama" },
                    { "f8dd43d2-d216-4e08-b79b-96982d8b90f0", "Action" }
                });

            migrationBuilder.InsertData(
                table: "Subscriptions",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { "1919fa93-d990-4d55-bb81-3c45c35be1dd", "Premium" },
                    { "89dfbeb0-2fb8-45bc-a1e0-9b63813aadbe", "Basic" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommentRatingUsers_CommentId",
                table: "CommentRatingUsers",
                column: "CommentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommentRatingUsers");

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

            migrationBuilder.AddColumn<string>(
                name: "ParentCommentId",
                table: "Comments",
                type: "nvarchar(450)",
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
                columns: new[] { "Id", "CreationDate", "Name" },
                values: new object[,]
                {
                    { "4bfc3a03-2e2a-40e7-b41d-37a31b02fb41", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thriller" },
                    { "5a7ce7f6-a716-4f7d-8089-a87b24f7ef9d", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mystery" },
                    { "835dda6e-aba6-4afa-aba4-28b94ab7dc0b", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Romance" },
                    { "903aefb6-bf6f-40fe-a4cc-c443a4cf08b1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Comedy" },
                    { "9708a973-9d46-40f6-a360-8ea6c5786906", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Horror" },
                    { "c36a5e4b-cba8-49cb-9e79-fd699348b813", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fantasy" },
                    { "f54439f0-ac54-4690-bf93-f8f23d31e4bb", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Drama" },
                    { "f8291155-66c8-478c-bbdf-9aa99a2800ac", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Action" }
                });

            migrationBuilder.InsertData(
                table: "Subscriptions",
                columns: new[] { "Id", "CreationDate", "Type" },
                values: new object[,]
                {
                    { "b444166e-f5f2-4e38-940e-07e32c60700e", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Premium" },
                    { "cce04694-bf6b-4bb9-8131-6c961c7583ab", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Basic" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ParentCommentId",
                table: "Comments",
                column: "ParentCommentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Comments_ParentCommentId",
                table: "Comments",
                column: "ParentCommentId",
                principalTable: "Comments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
