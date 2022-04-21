using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MensaGymnazium.IntranetGen3.Entity.Migrations
{
    public partial class StudentSeedEntityId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Teacher");

            migrationBuilder.AddColumn<int>(
                name: "SeedEntityId",
                table: "Student",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SeedEntityId",
                table: "Student");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Teacher",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
