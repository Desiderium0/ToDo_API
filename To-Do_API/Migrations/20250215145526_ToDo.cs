using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace To_Do_API.Migrations
{
    /// <inheritdoc />
    public partial class ToDo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_todoSet",
                table: "todoSet");

            migrationBuilder.RenameTable(
                name: "todoSet",
                newName: "ToDo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ToDo",
                table: "ToDo",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "ToDo",
                keyColumn: "Id",
                keyValue: -1,
                column: "Created",
                value: new DateTime(2025, 2, 15, 21, 55, 25, 851, DateTimeKind.Local).AddTicks(5769));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ToDo",
                table: "ToDo");

            migrationBuilder.RenameTable(
                name: "ToDo",
                newName: "todoSet");

            migrationBuilder.AddPrimaryKey(
                name: "PK_todoSet",
                table: "todoSet",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "todoSet",
                keyColumn: "Id",
                keyValue: -1,
                column: "Created",
                value: new DateTime(2025, 2, 15, 21, 50, 28, 13, DateTimeKind.Local).AddTicks(3903));
        }
    }
}
