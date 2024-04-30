using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MensaGymnazium.IntranetGen3.Entity.Migrations
{
    /// <inheritdoc />
    public partial class AddForeignLanguageCriteria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "CanUseForeignLanguageInsteadOfDonatedHours",
                table: "GradeRegistrationCriteria",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "RequiresForeginLanguage",
                table: "GradeRegistrationCriteria",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CanUseForeignLanguageInsteadOfDonatedHours",
                table: "GradeRegistrationCriteria");

            migrationBuilder.DropColumn(
                name: "RequiresForeginLanguage",
                table: "GradeRegistrationCriteria");
        }
    }
}
