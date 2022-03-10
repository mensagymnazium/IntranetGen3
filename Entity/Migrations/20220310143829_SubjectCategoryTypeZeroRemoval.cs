using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MensaGymnazium.IntranetGen3.Entity.Migrations
{
    public partial class SubjectCategoryTypeZeroRemoval : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.Sql(@"UPDATE Subject SET CategoryId = 1 WHERE CategoryId = 0
DELETE FROM SigningRuleSubjectCategoryRelation WHERE SubjectCategoryId = 0
DELETE FROM SubjectCategory WHERE Id = 0

DELETE FROM SubjectTypeRelation WHERE SubjectTypeId = 0
DELETE FROM SigningRuleSubjectTypeRelation WHERE SubjectTypeId = 0
DELETE FROM SubjectType WHERE Id = 0");
		}

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
