using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MensaGymnazium.IntranetGen3.Entity.Migrations
{
    /// <inheritdoc />
    public partial class DotatedHoursRenaming : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RequiredTotalAmountOfDonatedHoursExcludingLanguage",
                table: "GradeRegistrationCriteria",
                newName: "RequiredTotalAmountOfHoursPerWeekExcludingLanguage");

            migrationBuilder.RenameColumn(
                name: "RequiredAmountOfDonatedHoursInAreaCspOrCp",
                table: "GradeRegistrationCriteria",
                newName: "RequiredAmountOfHoursPerWeekInAreaCspOrCp");

            migrationBuilder.RenameColumn(
                name: "CanUseForeignLanguageInsteadOfDonatedHours",
                table: "GradeRegistrationCriteria",
                newName: "CanUseForeignLanguageInsteadOfHoursPerWeek");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RequiredTotalAmountOfHoursPerWeekExcludingLanguage",
                table: "GradeRegistrationCriteria",
                newName: "RequiredTotalAmountOfDonatedHoursExcludingLanguage");

            migrationBuilder.RenameColumn(
                name: "RequiredAmountOfHoursPerWeekInAreaCspOrCp",
                table: "GradeRegistrationCriteria",
                newName: "RequiredAmountOfDonatedHoursInAreaCspOrCp");

            migrationBuilder.RenameColumn(
                name: "CanUseForeignLanguageInsteadOfHoursPerWeek",
                table: "GradeRegistrationCriteria",
                newName: "CanUseForeignLanguageInsteadOfDonatedHours");
        }
    }
}
