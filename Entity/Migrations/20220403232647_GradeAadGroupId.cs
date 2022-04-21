using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MensaGymnazium.IntranetGen3.Entity.Migrations
{
    public partial class GradeAadGroupId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Grade",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AadGroupId",
                table: "Grade",
                type: "nvarchar(36)",
                maxLength: 36,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AadGroupId",
                table: "Grade");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Grade",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);
        }
    }
}
