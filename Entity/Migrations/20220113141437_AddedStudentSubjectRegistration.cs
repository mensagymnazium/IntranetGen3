using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MensaGymnazium.IntranetGen3.Entity.Migrations
{
    public partial class AddedStudentSubjectRegistration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StudentSubjectRegistration",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RegistrationType = table.Column<int>(type: "int", nullable: false),
                    UsedSigningRuleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentSubjectRegistration", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentSubjectRegistration_SigningRule_UsedSigningRuleId",
                        column: x => x.UsedSigningRuleId,
                        principalTable: "SigningRule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentSubjectRegistration_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentSubjectRegistration_Subject_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubjectRegistration_StudentId",
                table: "StudentSubjectRegistration",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubjectRegistration_SubjectId",
                table: "StudentSubjectRegistration",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubjectRegistration_UsedSigningRuleId",
                table: "StudentSubjectRegistration",
                column: "UsedSigningRuleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentSubjectRegistration");
        }
    }
}
