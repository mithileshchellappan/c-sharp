using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Forum.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationUserForumTopic");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "UserForumsId",
                table: "ForumTopics",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ForumTopicId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserForums",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserForums", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserForums_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ForumTopics_UserForumsId",
                table: "ForumTopics",
                column: "UserForumsId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ForumTopicId",
                table: "AspNetUsers",
                column: "ForumTopicId");

            migrationBuilder.CreateIndex(
                name: "IX_UserForums_UserId",
                table: "UserForums",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_ForumTopics_ForumTopicId",
                table: "AspNetUsers",
                column: "ForumTopicId",
                principalTable: "ForumTopics",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ForumTopics_UserForums_UserForumsId",
                table: "ForumTopics",
                column: "UserForumsId",
                principalTable: "UserForums",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_ForumTopics_ForumTopicId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_ForumTopics_UserForums_UserForumsId",
                table: "ForumTopics");

            migrationBuilder.DropTable(
                name: "UserForums");

            migrationBuilder.DropIndex(
                name: "IX_ForumTopics_UserForumsId",
                table: "ForumTopics");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ForumTopicId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserForumsId",
                table: "ForumTopics");

            migrationBuilder.DropColumn(
                name: "ForumTopicId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "ApplicationUserForumTopic",
                columns: table => new
                {
                    ForumsId = table.Column<int>(type: "int", nullable: false),
                    MembersId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserForumTopic", x => new { x.ForumsId, x.MembersId });
                    table.ForeignKey(
                        name: "FK_ApplicationUserForumTopic_AspNetUsers_MembersId",
                        column: x => x.MembersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationUserForumTopic_ForumTopics_ForumsId",
                        column: x => x.ForumsId,
                        principalTable: "ForumTopics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserForumTopic_MembersId",
                table: "ApplicationUserForumTopic",
                column: "MembersId");
        }
    }
}
