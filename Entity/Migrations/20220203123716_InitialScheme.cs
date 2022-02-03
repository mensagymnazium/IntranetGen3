using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MensaGymnazium.IntranetGen3.Entity.Migrations
{
    public partial class InitialScheme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "__DataSeed",
                columns: table => new
                {
                    ProfileName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Version = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataSeed", x => x.ProfileName);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Grade",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grade", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubjectCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubjectType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teacher",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    FunFact = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: true),
                    SeededEntityId = table.Column<int>(type: "int", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teacher", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SigningRule",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GradeId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SigningRule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SigningRule_Grade_GradeId",
                        column: x => x.GradeId,
                        principalTable: "Grade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GradeId = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Student_Grade_GradeId",
                        column: x => x.GradeId,
                        principalTable: "Grade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Subject",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    ScheduleDayOfWeek = table.Column<int>(type: "int", nullable: false),
                    ScheduleSlotInDay = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subject", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subject_SubjectCategory_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "SubjectCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SigningRuleSubjectCategoryRelation",
                columns: table => new
                {
                    SigningRuleId = table.Column<int>(type: "int", nullable: false),
                    SubjectCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SigningRuleSubjectCategoryRelation", x => new { x.SigningRuleId, x.SubjectCategoryId });
                    table.ForeignKey(
                        name: "FK_SigningRuleSubjectCategoryRelation_SigningRule_SigningRuleId",
                        column: x => x.SigningRuleId,
                        principalTable: "SigningRule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SigningRuleSubjectCategoryRelation_SubjectCategory_SubjectCategoryId",
                        column: x => x.SubjectCategoryId,
                        principalTable: "SubjectCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SigningRuleSubjectTypeRelation",
                columns: table => new
                {
                    SigningRuleId = table.Column<int>(type: "int", nullable: false),
                    SubjectTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SigningRuleSubjectTypeRelation", x => new { x.SigningRuleId, x.SubjectTypeId });
                    table.ForeignKey(
                        name: "FK_SigningRuleSubjectTypeRelation_SigningRule_SigningRuleId",
                        column: x => x.SigningRuleId,
                        principalTable: "SigningRule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SigningRuleSubjectTypeRelation_SubjectType_SubjectTypeId",
                        column: x => x.SubjectTypeId,
                        principalTable: "SubjectType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Oid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(320)", maxLength: 320, nullable: true),
                    StudentId = table.Column<int>(type: "int", nullable: true),
                    TeacherId = table.Column<int>(type: "int", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_User_Teacher_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teacher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "StudentSubjectRegistration",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RegistrationType = table.Column<int>(type: "int", nullable: false),
                    UsedSigningRuleId = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "SubjectTypeRelation",
                columns: table => new
                {
                    SubjectId = table.Column<int>(type: "int", nullable: false),
                    SubjectTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectTypeRelation", x => new { x.SubjectId, x.SubjectTypeId });
                    table.ForeignKey(
                        name: "FK_SubjectTypeRelation_Subject_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubjectTypeRelation_SubjectType_SubjectTypeId",
                        column: x => x.SubjectTypeId,
                        principalTable: "SubjectType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SigningRule_GradeId",
                table: "SigningRule",
                column: "GradeId");

            migrationBuilder.CreateIndex(
                name: "IX_SigningRuleSubjectCategoryRelation_SubjectCategoryId",
                table: "SigningRuleSubjectCategoryRelation",
                column: "SubjectCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SigningRuleSubjectTypeRelation_SubjectTypeId",
                table: "SigningRuleSubjectTypeRelation",
                column: "SubjectTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_GradeId",
                table: "Student",
                column: "GradeId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Subject_CategoryId",
                table: "Subject",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectGradeRelation_GradeId",
                table: "SubjectGradeRelation",
                column: "GradeId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectTeacherRelation_TeacherId",
                table: "SubjectTeacherRelation",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectTypeRelation_SubjectTypeId",
                table: "SubjectTypeRelation",
                column: "SubjectTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_User_Oid",
                table: "User",
                column: "Oid",
                unique: true,
                filter: "[Oid] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_User_StudentId",
                table: "User",
                column: "StudentId",
                unique: true,
                filter: "[StudentId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_User_TeacherId",
                table: "User",
                column: "TeacherId",
                unique: true,
                filter: "[TeacherId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "__DataSeed");

            migrationBuilder.DropTable(
                name: "ApplicationSettings");

            migrationBuilder.DropTable(
                name: "SigningRuleSubjectCategoryRelation");

            migrationBuilder.DropTable(
                name: "SigningRuleSubjectTypeRelation");

            migrationBuilder.DropTable(
                name: "StudentSubjectRegistration");

            migrationBuilder.DropTable(
                name: "SubjectGradeRelation");

            migrationBuilder.DropTable(
                name: "SubjectTeacherRelation");

            migrationBuilder.DropTable(
                name: "SubjectTypeRelation");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "SigningRule");

            migrationBuilder.DropTable(
                name: "Subject");

            migrationBuilder.DropTable(
                name: "SubjectType");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Teacher");

            migrationBuilder.DropTable(
                name: "SubjectCategory");

            migrationBuilder.DropTable(
                name: "Grade");
        }
    }
}
