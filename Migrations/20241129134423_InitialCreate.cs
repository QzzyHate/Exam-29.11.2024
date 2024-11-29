using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace newExam.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    number = table.Column<int>(type: "INTEGER", nullable: false),
                    addedDate = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    deviceType = table.Column<string>(type: "TEXT", nullable: true),
                    deviceModel = table.Column<string>(type: "TEXT", nullable: true),
                    description = table.Column<string>(type: "TEXT", nullable: true),
                    client = table.Column<string>(type: "TEXT", nullable: true),
                    phoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    stage = table.Column<string>(type: "TEXT", nullable: true),
                    status = table.Column<string>(type: "TEXT", nullable: true),
                    master = table.Column<string>(type: "TEXT", nullable: true),
                    masterComment = table.Column<string>(type: "TEXT", nullable: true),
                    complitedDate = table.Column<DateOnly>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
