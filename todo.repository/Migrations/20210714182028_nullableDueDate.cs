using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace todo.repository.Migrations
{
    public partial class nullableDueDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Due",
                table: "TodoTask",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "TodoTask",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Completed", "Due" },
                values: new object[] { false, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Due",
                table: "TodoTask",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "TodoTask",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Completed", "Due" },
                values: new object[] { true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
