using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MensaGymnazium.IntranetGen3.Entity.Migrations
{
    /// <inheritdoc />
    public partial class AddGradeRegistrationCriteria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RegistrationCriteriaId",
                table: "Grade",
                type: "int",
                nullable: true,
                defaultValue: null);

            migrationBuilder.CreateTable(
                name: "GradeRegistrationCriteria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    RequiredTotalAmountOfDonatedHoursExcludingLanguage = table.Column<int>(type: "int", nullable: false),
                    RequiresCspOrCpValidation = table.Column<bool>(type: "bit", nullable: false),
                    RequiredAmountOfDonatedHoursInAreaCspOrCp = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GradeRegistrationCriteria", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Grade_RegistrationCriteriaId",
                table: "Grade",
                column: "RegistrationCriteriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Grade_GradeRegistrationCriteria_RegistrationCriteriaId",
                table: "Grade",
                column: "RegistrationCriteriaId",
                principalTable: "GradeRegistrationCriteria",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grade_GradeRegistrationCriteria_RegistrationCriteriaId",
                table: "Grade");

            migrationBuilder.DropTable(
                name: "GradeRegistrationCriteria");

            migrationBuilder.DropIndex(
                name: "IX_Grade_RegistrationCriteriaId",
                table: "Grade");

            migrationBuilder.DropColumn(
                name: "RegistrationCriteriaId",
                table: "Grade");
        }
    }
}
