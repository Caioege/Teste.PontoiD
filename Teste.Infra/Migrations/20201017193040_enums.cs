using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Teste.Infra.Migrations
{
    public partial class enums : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Escola",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    Inep = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Escola", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Turma",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(nullable: true),
                    Serie = table.Column<int>(nullable: false),
                    Turno = table.Column<int>(nullable: false),
                    EscolaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turma", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Turma_Escola_EscolaId",
                        column: x => x.EscolaId,
                        principalTable: "Escola",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Aluno",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    Nascimento = table.Column<DateTime>(nullable: false),
                    Cpf = table.Column<string>(nullable: true),
                    TurmaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aluno", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Aluno_Turma_TurmaId",
                        column: x => x.TurmaId,
                        principalTable: "Turma",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Escola",
                columns: new[] { "Id", "Inep", "Nome" },
                values: new object[] { 1, 11111111, "Escola Ponto iD" });

            migrationBuilder.InsertData(
                table: "Escola",
                columns: new[] { "Id", "Inep", "Nome" },
                values: new object[] { 2, 22222222, "Escola São Benedito" });

            migrationBuilder.InsertData(
                table: "Turma",
                columns: new[] { "Id", "Descricao", "EscolaId", "Serie", "Turno" },
                values: new object[] { 1, "1º ANO A", 1, 0, 0 });

            migrationBuilder.InsertData(
                table: "Turma",
                columns: new[] { "Id", "Descricao", "EscolaId", "Serie", "Turno" },
                values: new object[] { 2, "1º ANO B", 1, 1, 2 });

            migrationBuilder.InsertData(
                table: "Turma",
                columns: new[] { "Id", "Descricao", "EscolaId", "Serie", "Turno" },
                values: new object[] { 3, "6º ANO A", 2, 5, 2 });

            migrationBuilder.InsertData(
                table: "Aluno",
                columns: new[] { "Id", "Cpf", "Nascimento", "Nome", "TurmaId" },
                values: new object[,]
                {
                    { 1, "70458342173", new DateTime(2013, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Caio Henrick", 1 },
                    { 2, "10203010112", new DateTime(2014, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Carlos Augusto", 1 },
                    { 3, "45672646813", new DateTime(2013, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wilter Porto", 2 },
                    { 4, "13564134352", new DateTime(2010, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thoru Emanuel", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aluno_TurmaId",
                table: "Aluno",
                column: "TurmaId");

            migrationBuilder.CreateIndex(
                name: "IX_Turma_EscolaId",
                table: "Turma",
                column: "EscolaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aluno");

            migrationBuilder.DropTable(
                name: "Turma");

            migrationBuilder.DropTable(
                name: "Escola");
        }
    }
}
