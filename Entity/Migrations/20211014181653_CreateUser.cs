using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MensaGymnazium.IntranetGen3.Entity.Migrations
{
	public partial class CreateUser : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "UserRole");

			migrationBuilder.DropTable(
				name: "Role");

			migrationBuilder.DropIndex(
				name: "IX_User_NormalizedEmail",
				table: "User");

			migrationBuilder.DropIndex(
				name: "IX_User_NormalizedUsername",
				table: "User");

			migrationBuilder.DropColumn(
				name: "AccessFailedCount",
				table: "User");

			migrationBuilder.DropColumn(
				name: "Created",
				table: "User");

			migrationBuilder.DropColumn(
				name: "Disabled",
				table: "User");

			migrationBuilder.DropColumn(
				name: "DisplayName",
				table: "User");

			migrationBuilder.DropColumn(
				name: "Email",
				table: "User");

			migrationBuilder.DropColumn(
				name: "EmailConfirmed",
				table: "User");

			migrationBuilder.DropColumn(
				name: "LockoutEnabled",
				table: "User");

			migrationBuilder.DropColumn(
				name: "LockoutEnd",
				table: "User");

			migrationBuilder.DropColumn(
				name: "NormalizedEmail",
				table: "User");

			migrationBuilder.DropColumn(
				name: "NormalizedUsername",
				table: "User");

			migrationBuilder.DropColumn(
				name: "PasswordHash",
				table: "User");

			migrationBuilder.DropColumn(
				name: "SecurityStamp",
				table: "User");

			migrationBuilder.DropColumn(
				name: "Username",
				table: "User");

			migrationBuilder.DropColumn(
				name: "MigrationId",
				table: "User");

			migrationBuilder.DropColumn(
				name: "Deleted",
				table: "User");

			migrationBuilder.AddColumn<bool>(
				name: "Deleted",
				table: "User",
				type: "bit",
				nullable: false,
				defaultValue: false);

			migrationBuilder.AddColumn<string>(
				name: "Name",
				table: "User",
				type: "nvarchar(64)",
				maxLength: 64,
				nullable: true,
				defaultValue: "Peter Parker");

			migrationBuilder.AddColumn<Guid>(
				name: "Oid",
				table: "User",
				type: "uniqueidentifier",
				nullable: false,
				defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

			migrationBuilder.AddColumn<int>(
				name: "StudentId",
				table: "User",
				type: "int",
				nullable: true);

			migrationBuilder.AddColumn<int>(
				name: "TeacherId",
				table: "User",
				type: "int",
				nullable: true);

			migrationBuilder.AddUniqueConstraint(
				name: "AK_User_Oid",
				table: "User",
				column: "Oid");

			migrationBuilder.CreateTable(
				name: "Student",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					GradeId = table.Column<int>(type: "int", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Student", x => x.Id);
					table.ForeignKey(
						name: "FK_Student_Grade_GradeId",
						column: x => x.GradeId,
						principalTable: "Grade",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "Teacher",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1")
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Teacher", x => x.Id);
				});

			migrationBuilder.CreateIndex(
				name: "IX_User_StudentId",
				table: "User",
				column: "StudentId",
				unique: true,
				filter: "[StudentId] IS NOT NULL");

			migrationBuilder.CreateIndex(
				name: "IX_User_TeacherId",
				table: "User",
				column: "TeacherId",
				unique: true,
				filter: "[TeacherId] IS NOT NULL");

			migrationBuilder.CreateIndex(
				name: "IX_Student_GradeId",
				table: "Student",
				column: "GradeId");

			migrationBuilder.AddForeignKey(
				name: "FK_User_Student_StudentId",
				table: "User",
				column: "StudentId",
				principalTable: "Student",
				principalColumn: "Id",
				onDelete: ReferentialAction.SetNull);

			migrationBuilder.AddForeignKey(
				name: "FK_User_Teacher_TeacherId",
				table: "User",
				column: "TeacherId",
				principalTable: "Teacher",
				principalColumn: "Id",
				onDelete: ReferentialAction.SetNull);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
				name: "FK_User_Student_StudentId",
				table: "User");

			migrationBuilder.DropForeignKey(
				name: "FK_User_Teacher_TeacherId",
				table: "User");

			migrationBuilder.DropTable(
				name: "Student");

			migrationBuilder.DropTable(
				name: "Teacher");

			migrationBuilder.DropUniqueConstraint(
				name: "AK_User_Oid",
				table: "User");

			migrationBuilder.DropIndex(
				name: "IX_User_StudentId",
				table: "User");

			migrationBuilder.DropIndex(
				name: "IX_User_TeacherId",
				table: "User");

			migrationBuilder.DropColumn(
				name: "Name",
				table: "User");

			migrationBuilder.DropColumn(
				name: "Oid",
				table: "User");

			migrationBuilder.DropColumn(
				name: "StudentId",
				table: "User");

			migrationBuilder.DropColumn(
				name: "TeacherId",
				table: "User");

			migrationBuilder.DropColumn(
				name: "Deleted",
				table: "User");

			migrationBuilder.AddColumn<int>(
				name: "MigrationId",
				table: "User",
				type: "int",
				nullable: true);

			migrationBuilder.AddColumn<DateTime>(
				name: "Deleted",
				table: "User",
				type: "datetime2",
				nullable: true);

			migrationBuilder.AddColumn<int>(
				name: "AccessFailedCount",
				table: "User",
				type: "int",
				nullable: false,
				defaultValue: 0);

			migrationBuilder.AddColumn<DateTime>(
				name: "Created",
				table: "User",
				type: "datetime2",
				nullable: false,
				defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

			migrationBuilder.AddColumn<bool>(
				name: "Disabled",
				table: "User",
				type: "bit",
				nullable: false,
				defaultValue: false);

			migrationBuilder.AddColumn<string>(
				name: "DisplayName",
				table: "User",
				type: "nvarchar(100)",
				maxLength: 100,
				nullable: true);

			migrationBuilder.AddColumn<string>(
				name: "Email",
				table: "User",
				type: "nvarchar(255)",
				maxLength: 255,
				nullable: true);

			migrationBuilder.AddColumn<bool>(
				name: "EmailConfirmed",
				table: "User",
				type: "bit",
				nullable: false,
				defaultValue: false);

			migrationBuilder.AddColumn<bool>(
				name: "LockoutEnabled",
				table: "User",
				type: "bit",
				nullable: false,
				defaultValue: false);

			migrationBuilder.AddColumn<DateTimeOffset>(
				name: "LockoutEnd",
				table: "User",
				type: "datetimeoffset",
				nullable: true);

			migrationBuilder.AddColumn<string>(
				name: "NormalizedEmail",
				table: "User",
				type: "nvarchar(255)",
				maxLength: 255,
				nullable: true);

			migrationBuilder.AddColumn<string>(
				name: "NormalizedUsername",
				table: "User",
				type: "nvarchar(50)",
				maxLength: 50,
				nullable: true);

			migrationBuilder.AddColumn<string>(
				name: "PasswordHash",
				table: "User",
				type: "nvarchar(max)",
				maxLength: 2147483647,
				nullable: true);

			migrationBuilder.AddColumn<string>(
				name: "SecurityStamp",
				table: "User",
				type: "nvarchar(255)",
				maxLength: 255,
				nullable: true);

			migrationBuilder.AddColumn<string>(
				name: "Username",
				table: "User",
				type: "nvarchar(50)",
				maxLength: 50,
				nullable: true);

			migrationBuilder.CreateTable(
				name: "Role",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false),
					Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
					NormalizedName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Role", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "UserRole",
				columns: table => new
				{
					UserId = table.Column<int>(type: "int", nullable: false),
					RoleId = table.Column<int>(type: "int", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_UserRole", x => new { x.UserId, x.RoleId });
					table.ForeignKey(
						name: "FK_UserRole_Role_RoleId",
						column: x => x.RoleId,
						principalTable: "Role",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_UserRole_User_UserId",
						column: x => x.UserId,
						principalTable: "User",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateIndex(
				name: "IX_User_NormalizedEmail",
				table: "User",
				column: "NormalizedEmail",
				unique: true,
				filter: "Deleted IS NULL");

			migrationBuilder.CreateIndex(
				name: "IX_User_NormalizedUsername",
				table: "User",
				column: "NormalizedUsername",
				unique: true,
				filter: "Deleted IS NULL");

			migrationBuilder.CreateIndex(
				name: "IX_UserRole_RoleId",
				table: "UserRole",
				column: "RoleId");
		}
	}
}
