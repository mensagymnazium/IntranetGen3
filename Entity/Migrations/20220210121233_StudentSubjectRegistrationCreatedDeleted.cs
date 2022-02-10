using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MensaGymnazium.IntranetGen3.Entity.Migrations
{
    public partial class StudentSubjectRegistrationCreatedDeleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreatedTime",
                table: "StudentSubjectRegistration",
                newName: "Created");

            migrationBuilder.AddColumn<DateTime>(
                name: "Deleted",
                table: "StudentSubjectRegistration",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "StudentSubjectRegistration");

            migrationBuilder.RenameColumn(
                name: "Created",
                table: "StudentSubjectRegistration",
                newName: "CreatedTime");
        }
    }
}
