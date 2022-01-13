using Microsoft.EntityFrameworkCore.Migrations;

namespace MensaGymnazium.IntranetGen3.Entity.Migrations
{
    public partial class SubjectCategoryNameLengthAdjustment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SigningRuleSubjectCategoryRelation_SubjectCategory_SubjectCategoryId",
                table: "SigningRuleSubjectCategoryRelation");

            migrationBuilder.DropForeignKey(
                name: "FK_Subject_SubjectCategory_CategoryId",
                table: "Subject");

            migrationBuilder.DropIndex(
                name: "IX_Subject_CategoryId",
                table: "Subject");

            migrationBuilder.DropIndex(
                name: "IX_SigningRuleSubjectCategoryRelation_SubjectCategoryId",
                table: "SigningRuleSubjectCategoryRelation");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "SubjectCategory",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CategoryId1",
                table: "Subject",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SubjectCategoryId1",
                table: "SigningRuleSubjectCategoryRelation",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Subject_CategoryId1",
                table: "Subject",
                column: "CategoryId1");

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
                name: "FK_Subject_SubjectCategory_CategoryId1",
                table: "Subject",
                column: "CategoryId1",
                principalTable: "SubjectCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SigningRuleSubjectCategoryRelation_SubjectCategory_SubjectCategoryId1",
                table: "SigningRuleSubjectCategoryRelation");

            migrationBuilder.DropForeignKey(
                name: "FK_Subject_SubjectCategory_CategoryId1",
                table: "Subject");

            migrationBuilder.DropIndex(
                name: "IX_Subject_CategoryId1",
                table: "Subject");

            migrationBuilder.DropIndex(
                name: "IX_SigningRuleSubjectCategoryRelation_SubjectCategoryId1",
                table: "SigningRuleSubjectCategoryRelation");

            migrationBuilder.DropColumn(
                name: "CategoryId1",
                table: "Subject");

            migrationBuilder.DropColumn(
                name: "SubjectCategoryId1",
                table: "SigningRuleSubjectCategoryRelation");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "SubjectCategory",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Subject_CategoryId",
                table: "Subject",
                column: "CategoryId");

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
                name: "FK_Subject_SubjectCategory_CategoryId",
                table: "Subject",
                column: "CategoryId",
                principalTable: "SubjectCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
