using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MensaGymnazium.IntranetGen3.Entity.Migrations
{
    public partial class ApplicationSettingsRenameFromAndToAndChangeType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CanRegisterSubjectFrom",
                table: "ApplicationSettings");

            migrationBuilder.DropColumn(
                name: "CanRegisterSubjectTo",
                table: "ApplicationSettings");

            migrationBuilder.AddColumn<DateTime>(
                name: "SubjectRegistrationAllowedFrom",
                table: "ApplicationSettings",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SubjectRegistrationAllowedTo",
                table: "ApplicationSettings",
                type: "datetime",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubjectRegistrationAllowedFrom",
                table: "ApplicationSettings");

            migrationBuilder.DropColumn(
                name: "SubjectRegistrationAllowedTo",
                table: "ApplicationSettings");

            migrationBuilder.AddColumn<DateTime>(
                name: "CanRegisterSubjectFrom",
                table: "ApplicationSettings",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CanRegisterSubjectTo",
                table: "ApplicationSettings",
                type: "datetime2",
                nullable: true);
        }
    }
}
