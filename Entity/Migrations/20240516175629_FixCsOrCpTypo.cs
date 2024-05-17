using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MensaGymnazium.IntranetGen3.Entity.Migrations
{
    /// <inheritdoc />
    public partial class FixCsOrCpTypo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RequiresCspOrCpValidation",
                table: "GradeRegistrationCriteria",
                newName: "RequiresCsOrCpValidation");

            migrationBuilder.RenameColumn(
                name: "RequiredAmountOfHoursPerWeekInAreaCspOrCp",
                table: "GradeRegistrationCriteria",
                newName: "RequiredAmountOfHoursPerWeekInAreaCsOrCp");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RequiresCsOrCpValidation",
                table: "GradeRegistrationCriteria",
                newName: "RequiresCspOrCpValidation");

            migrationBuilder.RenameColumn(
                name: "RequiredAmountOfHoursPerWeekInAreaCsOrCp",
                table: "GradeRegistrationCriteria",
                newName: "RequiredAmountOfHoursPerWeekInAreaCspOrCp");
        }
    }
}
