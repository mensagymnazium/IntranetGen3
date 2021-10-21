using Microsoft.EntityFrameworkCore.Migrations;

namespace MensaGymnazium.IntranetGen3.Entity.Migrations
{
    public partial class SubjectTypeRelationAddition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subject_SubjectType_TypeId",
                table: "Subject");

            migrationBuilder.DropIndex(
                name: "IX_Subject_TypeId",
                table: "Subject");

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
                        name: "FK_SubjectTypeRelation_Subject_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubjectTypeRelation_SubjectType_SubjectTypeId",
                        column: x => x.SubjectTypeId,
                        principalTable: "SubjectType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubjectTypeRelation_SubjectTypeId",
                table: "SubjectTypeRelation",
                column: "SubjectTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubjectTypeRelation");

            migrationBuilder.CreateIndex(
                name: "IX_Subject_TypeId",
                table: "Subject",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subject_SubjectType_TypeId",
                table: "Subject",
                column: "TypeId",
                principalTable: "SubjectType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
