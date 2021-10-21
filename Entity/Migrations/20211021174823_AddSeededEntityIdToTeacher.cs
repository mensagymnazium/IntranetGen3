using Microsoft.EntityFrameworkCore.Migrations;

namespace MensaGymnazium.IntranetGen3.Entity.Migrations
{
    public partial class AddSeededEntityIdToTeacher : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SeededEntityId",
                table: "Teacher",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SeededEntityId",
                table: "Teacher");
        }
    }
}
