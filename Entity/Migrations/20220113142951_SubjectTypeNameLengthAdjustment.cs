using Microsoft.EntityFrameworkCore.Migrations;

namespace MensaGymnazium.IntranetGen3.Entity.Migrations
{
    public partial class SubjectTypeNameLengthAdjustment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SigningRuleSubjectTypeRelation_SubjectType_SubjectTypeId",
                table: "SigningRuleSubjectTypeRelation");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectTypeRelation_SubjectType_SubjectTypeId",
                table: "SubjectTypeRelation");

            migrationBuilder.DropIndex(
                name: "IX_SubjectTypeRelation_SubjectTypeId",
                table: "SubjectTypeRelation");

            migrationBuilder.DropIndex(
                name: "IX_SigningRuleSubjectTypeRelation_SubjectTypeId",
                table: "SigningRuleSubjectTypeRelation");

            migrationBuilder.AddColumn<int>(
                name: "SubjectTypeId1",
                table: "SubjectTypeRelation",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "SubjectType",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SubjectTypeId1",
                table: "SigningRuleSubjectTypeRelation",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SubjectTypeRelation_SubjectTypeId1",
                table: "SubjectTypeRelation",
                column: "SubjectTypeId1");

            migrationBuilder.CreateIndex(
                name: "IX_SigningRuleSubjectTypeRelation_SubjectTypeId1",
                table: "SigningRuleSubjectTypeRelation",
                column: "SubjectTypeId1");

            migrationBuilder.AddForeignKey(
                name: "FK_SigningRuleSubjectTypeRelation_SubjectType_SubjectTypeId1",
                table: "SigningRuleSubjectTypeRelation",
                column: "SubjectTypeId1",
                principalTable: "SubjectType",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SigningRuleSubjectTypeRelation_SubjectType_SubjectTypeId1",
                table: "SigningRuleSubjectTypeRelation");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectTypeRelation_SubjectType_SubjectTypeId1",
                table: "SubjectTypeRelation");

            migrationBuilder.DropIndex(
                name: "IX_SubjectTypeRelation_SubjectTypeId1",
                table: "SubjectTypeRelation");

            migrationBuilder.DropIndex(
                name: "IX_SigningRuleSubjectTypeRelation_SubjectTypeId1",
                table: "SigningRuleSubjectTypeRelation");

            migrationBuilder.DropColumn(
                name: "SubjectTypeId1",
                table: "SubjectTypeRelation");

            migrationBuilder.DropColumn(
                name: "SubjectTypeId1",
                table: "SigningRuleSubjectTypeRelation");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "SubjectType",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SubjectTypeRelation_SubjectTypeId",
                table: "SubjectTypeRelation",
                column: "SubjectTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SigningRuleSubjectTypeRelation_SubjectTypeId",
                table: "SigningRuleSubjectTypeRelation",
                column: "SubjectTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_SigningRuleSubjectTypeRelation_SubjectType_SubjectTypeId",
                table: "SigningRuleSubjectTypeRelation",
                column: "SubjectTypeId",
                principalTable: "SubjectType",
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
    }
}
