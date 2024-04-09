using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MensaGymnazium.IntranetGen3.Entity.Migrations
{
    /// <inheritdoc />
    public partial class RemoveSigningRule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentSubjectRegistration_SigningRule_UsedSigningRuleId",
                table: "StudentSubjectRegistration");

            migrationBuilder.DropTable(
                name: "SigningRuleSubjectCategoryRelation");

            migrationBuilder.DropTable(
                name: "SigningRuleSubjectTypeRelation");

            migrationBuilder.DropTable(
                name: "SigningRule");

            migrationBuilder.DropIndex(
                name: "IX_StudentSubjectRegistration_UsedSigningRuleId",
                table: "StudentSubjectRegistration");

            migrationBuilder.DropColumn(
                name: "UsedSigningRuleId",
                table: "StudentSubjectRegistration");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsedSigningRuleId",
                table: "StudentSubjectRegistration",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "SigningRule",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GradeId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    SeedItemIdentifier = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
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

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubjectRegistration_UsedSigningRuleId",
                table: "StudentSubjectRegistration",
                column: "UsedSigningRuleId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_StudentSubjectRegistration_SigningRule_UsedSigningRuleId",
                table: "StudentSubjectRegistration",
                column: "UsedSigningRuleId",
                principalTable: "SigningRule",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
