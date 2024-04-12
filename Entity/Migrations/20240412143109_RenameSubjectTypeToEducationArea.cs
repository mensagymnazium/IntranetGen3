using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MensaGymnazium.IntranetGen3.Entity.Migrations
{
    /// <inheritdoc />
    public partial class RenameSubjectTypeToEducationArea : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubjectTypeRelation");

            migrationBuilder.DropTable(
                name: "SubjectType");

            migrationBuilder.CreateTable(
                name: "EducationalArea",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationalArea", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EducationalAreaRelation",
                columns: table => new
                {
                    SubjectId = table.Column<int>(type: "int", nullable: false),
                    EducationalAreaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationalAreaRelation", x => new { x.SubjectId, x.EducationalAreaId });
                    table.ForeignKey(
                        name: "FK_EducationalAreaRelation_EducationalArea_EducationalAreaId",
                        column: x => x.EducationalAreaId,
                        principalTable: "EducationalArea",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EducationalAreaRelation_Subject_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EducationalAreaRelation_EducationalAreaId",
                table: "EducationalAreaRelation",
                column: "EducationalAreaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EducationalAreaRelation");

            migrationBuilder.DropTable(
                name: "EducationalArea");

            migrationBuilder.CreateTable(
                name: "SubjectType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubjectTypeRelation",
                columns: table => new
                {
                    SubjectId = table.Column<int>(type: "int", nullable: false),
                    SubjectTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectTypeRelation", x => new { x.SubjectId, x.SubjectTypeId });
                    table.ForeignKey(
                        name: "FK_SubjectTypeRelation_SubjectType_SubjectTypeId",
                        column: x => x.SubjectTypeId,
                        principalTable: "SubjectType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubjectTypeRelation_Subject_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubjectTypeRelation_SubjectTypeId",
                table: "SubjectTypeRelation",
                column: "SubjectTypeId");
        }
    }
}
