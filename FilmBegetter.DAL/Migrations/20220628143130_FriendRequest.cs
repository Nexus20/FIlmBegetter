using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmBegetter.DAL.Migrations
{
    public partial class FriendRequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7352beca-067b-415a-a6b3-37d6043c3f51");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "de0c1822-f50a-41dc-bd09-0a5f1f852dc2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fa55fb73-33ba-486b-b952-a0fd1c952967");

            migrationBuilder.DeleteData(
                table: "Subscriptions",
                keyColumn: "Id",
                keyValue: "0deaa0b5-24f4-4ef1-bb92-9b2bda2e483a");

            migrationBuilder.DeleteData(
                table: "Subscriptions",
                keyColumn: "Id",
                keyValue: "3893e6fb-538f-4bfb-a2ae-dda951c17b58");

            migrationBuilder.CreateTable(
                name: "FriendRequests",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SenderId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RecipientId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FriendRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FriendRequests_AspNetUsers_RecipientId",
                        column: x => x.RecipientId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FriendRequests_AspNetUsers_SenderId",
                        column: x => x.SenderId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3fb36f3a-90b2-4342-823d-1ca8d4b24539", "dfa54036-755a-4b3e-8c16-5b531d361c8e", "Moderator", "MODERATOR" },
                    { "4993bbe6-4427-4583-8817-3f9d1f9d59fb", "0094d926-77ef-4ed1-97a7-93c60049f89b", "User", "USER" },
                    { "ab93d092-3892-4a1d-a4cf-44e05fc5e9ee", "fd611a4e-aa85-4bdf-8da2-929b74eab3a0", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "Subscriptions",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { "12831af1-5409-4677-a2cc-791365088523", "Premium" },
                    { "26f9dc90-3001-42ad-a778-808859c48395", "Basic" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_FriendRequests_RecipientId",
                table: "FriendRequests",
                column: "RecipientId");

            migrationBuilder.CreateIndex(
                name: "IX_FriendRequests_SenderId",
                table: "FriendRequests",
                column: "SenderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FriendRequests");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3fb36f3a-90b2-4342-823d-1ca8d4b24539");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4993bbe6-4427-4583-8817-3f9d1f9d59fb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ab93d092-3892-4a1d-a4cf-44e05fc5e9ee");

            migrationBuilder.DeleteData(
                table: "Subscriptions",
                keyColumn: "Id",
                keyValue: "12831af1-5409-4677-a2cc-791365088523");

            migrationBuilder.DeleteData(
                table: "Subscriptions",
                keyColumn: "Id",
                keyValue: "26f9dc90-3001-42ad-a778-808859c48395");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7352beca-067b-415a-a6b3-37d6043c3f51", "8f24b663-e68e-4095-85c2-522fe97eca07", "Moderator", "MODERATOR" },
                    { "de0c1822-f50a-41dc-bd09-0a5f1f852dc2", "4a59326a-9976-4b9c-858c-ef0cf6851867", "Admin", "ADMIN" },
                    { "fa55fb73-33ba-486b-b952-a0fd1c952967", "5042ef68-9153-4268-a128-f83609e52e00", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "Subscriptions",
                columns: new[] { "Id", "CreationDate", "Type" },
                values: new object[,]
                {
                    { "0deaa0b5-24f4-4ef1-bb92-9b2bda2e483a", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Premium" },
                    { "3893e6fb-538f-4bfb-a2ae-dda951c17b58", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Basic" }
                });
        }
    }
}
