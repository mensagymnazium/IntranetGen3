using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MensaGymnazium.IntranetGen3.Entity.Migrations
{
    public partial class ApplicationSettingsAddRegisterFromToDateTimes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CanRegisterSubjectFrom",
                table: "ApplicationSettings");

            migrationBuilder.DropColumn(
                name: "CanRegisterSubjectTo",
                table: "ApplicationSettings");
        }
    }
}
