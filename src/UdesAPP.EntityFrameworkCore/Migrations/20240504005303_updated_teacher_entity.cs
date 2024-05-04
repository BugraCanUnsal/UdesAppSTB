using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UdesAPP.Migrations
{
    /// <inheritdoc />
    public partial class updated_teacher_entity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Debt",
                table: "AppTeachers",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "GroupLessonFee",
                table: "AppTeachers",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "IndividualLessonFee",
                table: "AppTeachers",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Debt",
                table: "AppTeachers");

            migrationBuilder.DropColumn(
                name: "GroupLessonFee",
                table: "AppTeachers");

            migrationBuilder.DropColumn(
                name: "IndividualLessonFee",
                table: "AppTeachers");
        }
    }
}
