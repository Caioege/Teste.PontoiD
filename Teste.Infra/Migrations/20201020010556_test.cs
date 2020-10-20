using Microsoft.EntityFrameworkCore.Migrations;

namespace Teste.Infra.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Turma",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Serie", "Turno" },
                values: new object[] { 0, 1 });

            migrationBuilder.UpdateData(
                table: "Turma",
                keyColumn: "Id",
                keyValue: 3,
                column: "Turno",
                value: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Turma",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Serie", "Turno" },
                values: new object[] { 1, 2 });

            migrationBuilder.UpdateData(
                table: "Turma",
                keyColumn: "Id",
                keyValue: 3,
                column: "Turno",
                value: 2);
        }
    }
}
