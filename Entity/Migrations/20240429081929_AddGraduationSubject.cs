using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MensaGymnazium.IntranetGen3.Entity.Migrations
{
    /// <inheritdoc />
    public partial class AddGraduationSubject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GraduationSubject",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GraduationSubject", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GraduationSubjectRelation",
                columns: table => new
                {
                    SubjectId = table.Column<int>(type: "int", nullable: false),
                    GraduationSubjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GraduationSubjectRelation", x => new { x.SubjectId, x.GraduationSubjectId });
                    table.ForeignKey(
                        name: "FK_GraduationSubjectRelation_GraduationSubject_GraduationSubjectId",
                        column: x => x.GraduationSubjectId,
                        principalTable: "GraduationSubject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GraduationSubjectRelation_Subject_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GraduationSubjectRelation_GraduationSubjectId",
                table: "GraduationSubjectRelation",
                column: "GraduationSubjectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GraduationSubjectRelation");

            migrationBuilder.DropTable(
                name: "GraduationSubject");
        }
    }
}
