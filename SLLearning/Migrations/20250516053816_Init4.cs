using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SLLearning.Migrations
{
    /// <inheritdoc />
    public partial class Init4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Members_Enrolments_EnrolmentId",
                table: "Members");

            migrationBuilder.DropTable(
                name: "LessonMember");

            migrationBuilder.DropIndex(
                name: "IX_Members_EnrolmentId",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "EnrolmentId",
                table: "Members");

            migrationBuilder.CreateIndex(
                name: "IX_Enrolments_LessonId",
                table: "Enrolments",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrolments_MemberId",
                table: "Enrolments",
                column: "MemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_Enrolments_Lesson_LessonId",
                table: "Enrolments",
                column: "LessonId",
                principalTable: "Lesson",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Enrolments_Members_MemberId",
                table: "Enrolments",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enrolments_Lesson_LessonId",
                table: "Enrolments");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrolments_Members_MemberId",
                table: "Enrolments");

            migrationBuilder.DropIndex(
                name: "IX_Enrolments_LessonId",
                table: "Enrolments");

            migrationBuilder.DropIndex(
                name: "IX_Enrolments_MemberId",
                table: "Enrolments");

            migrationBuilder.AddColumn<int>(
                name: "EnrolmentId",
                table: "Members",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "LessonMember",
                columns: table => new
                {
                    LessonsId = table.Column<int>(type: "int", nullable: false),
                    MembersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonMember", x => new { x.LessonsId, x.MembersId });
                    table.ForeignKey(
                        name: "FK_LessonMember_Lesson_LessonsId",
                        column: x => x.LessonsId,
                        principalTable: "Lesson",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LessonMember_Members_MembersId",
                        column: x => x.MembersId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Members_EnrolmentId",
                table: "Members",
                column: "EnrolmentId");

            migrationBuilder.CreateIndex(
                name: "IX_LessonMember_MembersId",
                table: "LessonMember",
                column: "MembersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Members_Enrolments_EnrolmentId",
                table: "Members",
                column: "EnrolmentId",
                principalTable: "Enrolments",
                principalColumn: "Id");
        }
    }
}
