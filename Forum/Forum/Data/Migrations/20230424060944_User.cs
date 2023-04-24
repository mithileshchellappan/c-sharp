using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Forum.Data.Migrations
{
    public partial class User : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
           ;

            migrationBuilder.DropTable(
                name: "ApplicationUserForumTopic");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");
        }
    }
}
