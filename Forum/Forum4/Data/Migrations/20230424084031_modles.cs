using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Forum4.Data.Migrations
{
    public partial class modles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "ForumTopics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserForumsId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForumTopics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ForumTopics_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ForumTopics_UserForums_UserForumsId",
                        column: x => x.UserForumsId,
                        principalTable: "UserForums",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ForumInvites",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ForumTopicId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForumInvites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ForumInvites_ForumTopics_ForumTopicId",
                        column: x => x.ForumTopicId,
                        principalTable: "ForumTopics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ForumMessages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ForumTopicId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForumMessages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ForumMessages_ForumTopics_ForumTopicId",
                        column: x => x.ForumTopicId,
                        principalTable: "ForumTopics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ForumTopicId",
                table: "AspNetUsers",
                column: "ForumTopicId");

            migrationBuilder.CreateIndex(
                name: "IX_ForumInvites_ForumTopicId",
                table: "ForumInvites",
                column: "ForumTopicId");

            migrationBuilder.CreateIndex(
                name: "IX_ForumMessages_ForumTopicId",
                table: "ForumMessages",
                column: "ForumTopicId");

            migrationBuilder.CreateIndex(
                name: "IX_ForumTopics_CreatedById",
                table: "ForumTopics",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ForumTopics_UserForumsId",
                table: "ForumTopics",
                column: "UserForumsId");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_ForumTopics_ForumTopicId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "ForumInvites");

            migrationBuilder.DropTable(
                name: "ForumMessages");

            migrationBuilder.DropTable(
                name: "ForumTopics");

            migrationBuilder.DropTable(
                name: "UserForums");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ForumTopicId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ForumTopicId",
                table: "AspNetUsers");
        }
    }
}
