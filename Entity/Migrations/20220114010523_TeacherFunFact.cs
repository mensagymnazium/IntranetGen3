using Microsoft.EntityFrameworkCore.Migrations;

namespace MensaGymnazium.IntranetGen3.Entity.Migrations
{
    public partial class TeacherFunFact : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SigningRuleSubjectCategoryRelation_SubjectCategory_SubjectCategoryId1",
                table: "SigningRuleSubjectCategoryRelation");

            migrationBuilder.DropForeignKey(
                name: "FK_SigningRuleSubjectTypeRelation_SubjectType_SubjectTypeId1",
                table: "SigningRuleSubjectTypeRelation");

            migrationBuilder.DropForeignKey(
                name: "FK_Subject_SubjectCategory_CategoryId1",
                table: "Subject");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectTypeRelation_SubjectType_SubjectTypeId1",
                table: "SubjectTypeRelation");

            migrationBuilder.DropIndex(
                name: "IX_SubjectTypeRelation_SubjectTypeId1",
                table: "SubjectTypeRelation");

            migrationBuilder.DropIndex(
                name: "IX_Subject_CategoryId1",
                table: "Subject");

            migrationBuilder.DropIndex(
                name: "IX_SigningRuleSubjectTypeRelation_SubjectTypeId1",
                table: "SigningRuleSubjectTypeRelation");

            migrationBuilder.DropIndex(
                name: "IX_SigningRuleSubjectCategoryRelation_SubjectCategoryId1",
                table: "SigningRuleSubjectCategoryRelation");

            migrationBuilder.DropColumn(
                name: "SubjectTypeId1",
                table: "SubjectTypeRelation");

            migrationBuilder.DropColumn(
                name: "CategoryId1",
                table: "Subject");

            migrationBuilder.DropColumn(
                name: "SubjectTypeId1",
                table: "SigningRuleSubjectTypeRelation");

            migrationBuilder.DropColumn(
                name: "SubjectCategoryId1",
                table: "SigningRuleSubjectCategoryRelation");

            migrationBuilder.AddColumn<string>(
                name: "FunFact",
                table: "Teacher",
                type: "nvarchar(max)",
                maxLength: 2147483647,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Teacher",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "UsedSigningRuleId",
                table: "StudentSubjectRegistration",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SubjectId",
                table: "StudentSubjectRegistration",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SubjectTypeRelation_SubjectTypeId",
                table: "SubjectTypeRelation",
                column: "SubjectTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Subject_CategoryId",
                table: "Subject",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SigningRuleSubjectTypeRelation_SubjectTypeId",
                table: "SigningRuleSubjectTypeRelation",
                column: "SubjectTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SigningRuleSubjectCategoryRelation_SubjectCategoryId",
                table: "SigningRuleSubjectCategoryRelation",
                column: "SubjectCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_SigningRuleSubjectCategoryRelation_SubjectCategory_SubjectCategoryId",
                table: "SigningRuleSubjectCategoryRelation",
                column: "SubjectCategoryId",
                principalTable: "SubjectCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SigningRuleSubjectTypeRelation_SubjectType_SubjectTypeId",
                table: "SigningRuleSubjectTypeRelation",
                column: "SubjectTypeId",
                principalTable: "SubjectType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Subject_SubjectCategory_CategoryId",
                table: "Subject",
                column: "CategoryId",
                principalTable: "SubjectCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectTypeRelation_SubjectType_SubjectTypeId",
                table: "SubjectTypeRelation",
                column: "SubjectTypeId",
                principalTable: "SubjectType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SigningRuleSubjectCategoryRelation_SubjectCategory_SubjectCategoryId",
                table: "SigningRuleSubjectCategoryRelation");

            migrationBuilder.DropForeignKey(
                name: "FK_SigningRuleSubjectTypeRelation_SubjectType_SubjectTypeId",
                table: "SigningRuleSubjectTypeRelation");

            migrationBuilder.DropForeignKey(
                name: "FK_Subject_SubjectCategory_CategoryId",
                table: "Subject");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectTypeRelation_SubjectType_SubjectTypeId",
                table: "SubjectTypeRelation");

            migrationBuilder.DropIndex(
                name: "IX_SubjectTypeRelation_SubjectTypeId",
                table: "SubjectTypeRelation");

            migrationBuilder.DropIndex(
                name: "IX_Subject_CategoryId",
                table: "Subject");

            migrationBuilder.DropIndex(
                name: "IX_SigningRuleSubjectTypeRelation_SubjectTypeId",
                table: "SigningRuleSubjectTypeRelation");

            migrationBuilder.DropIndex(
                name: "IX_SigningRuleSubjectCategoryRelation_SubjectCategoryId",
                table: "SigningRuleSubjectCategoryRelation");

            migrationBuilder.DropColumn(
                name: "FunFact",
                table: "Teacher");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Teacher");

            migrationBuilder.AddColumn<int>(
                name: "SubjectTypeId1",
                table: "SubjectTypeRelation",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CategoryId1",
                table: "Subject",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UsedSigningRuleId",
                table: "StudentSubjectRegistration",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "SubjectId",
                table: "StudentSubjectRegistration",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "SubjectTypeId1",
                table: "SigningRuleSubjectTypeRelation",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SubjectCategoryId1",
                table: "SigningRuleSubjectCategoryRelation",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SubjectTypeRelation_SubjectTypeId1",
                table: "SubjectTypeRelation",
                column: "SubjectTypeId1");

            migrationBuilder.CreateIndex(
                name: "IX_Subject_CategoryId1",
                table: "Subject",
                column: "CategoryId1");

            migrationBuilder.CreateIndex(
                name: "IX_SigningRuleSubjectTypeRelation_SubjectTypeId1",
                table: "SigningRuleSubjectTypeRelation",
                column: "SubjectTypeId1");

            migrationBuilder.CreateIndex(
                name: "IX_SigningRuleSubjectCategoryRelation_SubjectCategoryId1",
                table: "SigningRuleSubjectCategoryRelation",
                column: "SubjectCategoryId1");

            migrationBuilder.AddForeignKey(
                name: "FK_SigningRuleSubjectCategoryRelation_SubjectCategory_SubjectCategoryId1",
                table: "SigningRuleSubjectCategoryRelation",
                column: "SubjectCategoryId1",
                principalTable: "SubjectCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SigningRuleSubjectTypeRelation_SubjectType_SubjectTypeId1",
                table: "SigningRuleSubjectTypeRelation",
                column: "SubjectTypeId1",
                principalTable: "SubjectType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Subject_SubjectCategory_CategoryId1",
                table: "Subject",
                column: "CategoryId1",
                principalTable: "SubjectCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectTypeRelation_SubjectType_SubjectTypeId1",
                table: "SubjectTypeRelation",
                column: "SubjectTypeId1",
                principalTable: "SubjectType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
