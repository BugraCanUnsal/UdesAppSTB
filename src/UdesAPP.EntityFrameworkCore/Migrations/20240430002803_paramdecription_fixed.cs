using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UdesAPP.Migrations
{
    /// <inheritdoc />
    public partial class paramdecription_fixed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ParamDecription",
                table: "AppParameters",
                newName: "ParamDescription");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ParamDescription",
                table: "AppParameters",
                newName: "ParamDecription");
        }
    }
}
