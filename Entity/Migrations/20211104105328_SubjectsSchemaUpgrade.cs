using Microsoft.EntityFrameworkCore.Migrations;

namespace MensaGymnazium.IntranetGen3.Entity.Migrations
{
    public partial class SubjectsSchemaUpgrade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TypeId",
                table: "Subject",
                newName: "ScheduleSlotInDay");

            migrationBuilder.AddColumn<int>(
                name: "ScheduleDayOfWeek",
                table: "Subject",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "SubjectGradeRelation",
                columns: table => new
                {
                    SubjectId = table.Column<int>(type: "int", nullable: false),
                    GradeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectGradeRelation", x => new { x.SubjectId, x.GradeId });
                    table.ForeignKey(
                        name: "FK_SubjectGradeRelation_Grade_GradeId",
                        column: x => x.GradeId,
                        principalTable: "Grade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubjectGradeRelation_Subject_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubjectTeacherRelation",
                columns: table => new
                {
                    SubjectId = table.Column<int>(type: "int", nullable: false),
                    TeacherId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectTeacherRelation", x => new { x.SubjectId, x.TeacherId });
                    table.ForeignKey(
                        name: "FK_SubjectTeacherRelation_Subject_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubjectTeacherRelation_Teacher_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teacher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubjectGradeRelation_GradeId",
                table: "SubjectGradeRelation",
                column: "GradeId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectTeacherRelation_TeacherId",
                table: "SubjectTeacherRelation",
                column: "TeacherId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubjectGradeRelation");

            migrationBuilder.DropTable(
                name: "SubjectTeacherRelation");

            migrationBuilder.DropColumn(
                name: "ScheduleDayOfWeek",
                table: "Subject");

            migrationBuilder.RenameColumn(
                name: "ScheduleSlotInDay",
                table: "Subject",
                newName: "TypeId");
        }
    }
}
