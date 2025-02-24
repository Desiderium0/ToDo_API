using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace To_Do_API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "todoSet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_todoSet", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "todoSet",
                columns: new[] { "Id", "Created", "Description", "IsCompleted", "LastUpdated", "Title" },
                values: new object[] { -1, new DateTime(2025, 2, 15, 21, 50, 28, 13, DateTimeKind.Local).AddTicks(3903), "Завтра поехать всретить Машу с вокзала!!!", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Testing" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "todoSet");
        }
    }
}
