using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MensaGymnazium.IntranetGen3.Entity.Migrations
{
    public partial class SigningRuleSeeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.Sql(@"
				DELETE FROM SigningRuleSubjectTypeRelation;
				DELETE FROM SigningRuleSubjectCategoryRelation;
				DELETE FROM StudentSubjectRegistration;
				DELETE FROM SigningRule;
			");

            migrationBuilder.AddColumn<string>(
                name: "SeedItemIdentifier",
                table: "SigningRule",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SeedItemIdentifier",
                table: "SigningRule");
        }
    }
}
