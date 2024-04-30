using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UdesAPP.Migrations
{
    /// <inheritdoc />
    public partial class Created_Parameter_Entity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppParameters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Paramtype = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    ParamCode = table.Column<int>(type: "int", nullable: false),
                    ParamDecription = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ParamValue1 = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    ParamValue2 = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    ParamValue3 = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    ParamValue4 = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    ParamValue5 = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppParameters", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppParameters");
        }
    }
}
