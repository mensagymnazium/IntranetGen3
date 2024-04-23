using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MensaGymnazium.IntranetGen3.Entity.Migrations
{
    /// <inheritdoc />
    public partial class AddMinStudentsToOpen : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MinStudentsToOpen",
                table: "Subject",
                type: "int",
                nullable: false,
                defaultValue: 5);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MinStudentsToOpen",
                table: "Subject");
        }
    }
}
