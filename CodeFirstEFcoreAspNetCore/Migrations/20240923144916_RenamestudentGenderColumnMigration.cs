using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeFirstEFcoreAspNetCore.Migrations
{
    /// <inheritdoc />
    public partial class RenamestudentGenderColumnMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "studentGender",
                table: "Students",
                newName: "StudentGender");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StudentGender",
                table: "Students",
                newName: "studentGender");
        }
    }
}
