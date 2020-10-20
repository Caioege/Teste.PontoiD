﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Teste.Infra.DataContext;

namespace Teste.Infra.Migrations
{
    [DbContext(typeof(PontoiDTesteDb))]
    [Migration("20201020010556_test")]
    partial class test
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Teste.Dominio.Models.Aluno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Cpf")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("Nascimento")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Nome")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int?>("TurmaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TurmaId");

                    b.ToTable("Aluno");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Cpf = "70458342173",
                            Nascimento = new DateTime(2013, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nome = "Caio Henrick",
                            TurmaId = 1
                        },
                        new
                        {
                            Id = 2,
                            Cpf = "10203010112",
                            Nascimento = new DateTime(2014, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nome = "Carlos Augusto",
                            TurmaId = 1
                        },
                        new
                        {
                            Id = 3,
                            Cpf = "45672646813",
                            Nascimento = new DateTime(2013, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nome = "Wilter Porto",
                            TurmaId = 2
                        },
                        new
                        {
                            Id = 4,
                            Cpf = "13564134352",
                            Nascimento = new DateTime(2010, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nome = "Thoru Emanuel",
                            TurmaId = 3
                        });
                });

            modelBuilder.Entity("Teste.Dominio.Models.Escola", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Inep")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Escola");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Inep = 11111111,
                            Nome = "Escola Ponto iD"
                        },
                        new
                        {
                            Id = 2,
                            Inep = 22222222,
                            Nome = "Escola São Benedito"
                        });
                });

            modelBuilder.Entity("Teste.Dominio.Models.Turma", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("EscolaId")
                        .HasColumnType("int");

                    b.Property<int>("Serie")
                        .HasColumnType("int");

                    b.Property<int>("Turno")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EscolaId");

                    b.ToTable("Turma");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Descricao = "1º ANO A",
                            EscolaId = 1,
                            Serie = 0,
                            Turno = 0
                        },
                        new
                        {
                            Id = 2,
                            Descricao = "1º ANO B",
                            EscolaId = 1,
                            Serie = 0,
                            Turno = 1
                        },
                        new
                        {
                            Id = 3,
                            Descricao = "6º ANO A",
                            EscolaId = 2,
                            Serie = 5,
                            Turno = 1
                        });
                });

            modelBuilder.Entity("Teste.Dominio.Models.Aluno", b =>
                {
                    b.HasOne("Teste.Dominio.Models.Turma", "TurmaAluno")
                        .WithMany("Alunos")
                        .HasForeignKey("TurmaId");
                });

            modelBuilder.Entity("Teste.Dominio.Models.Turma", b =>
                {
                    b.HasOne("Teste.Dominio.Models.Escola", "EscolaTurma")
                        .WithMany("Turmas")
                        .HasForeignKey("EscolaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
