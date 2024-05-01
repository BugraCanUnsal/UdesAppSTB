using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UdesAPP.Migrations
{
    /// <inheritdoc />
    public partial class Created_PotentialStudent_Entity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppPotentialStudents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    StudentSurname = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    GSM = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    EMail = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: true),
                    Note = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    PotGroup = table.Column<bool>(type: "bit", nullable: false),
                    PotIndividual = table.Column<bool>(type: "bit", nullable: false),
                    WeekDays = table.Column<bool>(type: "bit", nullable: false),
                    Weekends = table.Column<bool>(type: "bit", nullable: false),
                    GroupLessonFee = table.Column<int>(type: "int", nullable: false),
                    IndividualLessonFee = table.Column<int>(type: "int", nullable: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppPotentialStudents", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppPotentialStudents");
        }
    }
}
