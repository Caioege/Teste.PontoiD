using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Teste.Dominio.Models;

namespace Teste.Infra.DataContext
{
    public class PontoiDTesteDb : DbContext
    {
        public PontoiDTesteDb(DbContextOptions<PontoiDTesteDb> options) : base(options)
        {
        }

        public DbSet<Escola> Escola { get; set; }
        public DbSet<Turma> Turma { get; set; }
        public DbSet<Aluno> Aluno { get; set; }

        //CARGA INICIAL PARA O BANCO DE DADOS
        protected override void OnModelCreating(ModelBuilder builder)
        {
            #region Escola

            builder.Entity<Escola>()
                .HasData(
                    new List<Escola>()
                    {
                        new Escola()
                        {
                            Id = 1,
                            Nome = "Escola Ponto iD",
                            Inep = 11111111
                        },
                        new Escola()
                        {
                            Id = 2,
                            Nome = "Escola São Benedito",
                            Inep = 22222222
                        }
                    }
                );

            #endregion

            #region Turma

            builder.Entity<Turma>()
                .HasData(
                    new List<Turma>()
                    {
                        new Turma()
                        {
                            Id = 1,
                            Descricao = "1º ANO A",
                            Serie = "1º",
                            Turno = "Matutino",
                            EscolaId = 1
                        },
                        new Turma()
                        {
                            Id = 2,
                            Descricao = "1º ANO B",
                            Serie = "1º",
                            Turno = "Vespertino",
                            EscolaId = 1
                        },
                        new Turma()
                        {
                            Id = 3,
                            Descricao = "6º ANO A",
                            Serie = "6º",
                            Turno = "Vespertino",
                            EscolaId = 2
                        }
                    }
                );
            #endregion

            #region Aluno

            builder.Entity<Aluno>()
                .HasData(
                    new List<Aluno>()
                    {
                        new Aluno()
                        {
                            Id = 1,
                            Nome = "Caio Henrick",
                            Cpf = "70458342173",
                            Nascimento = Convert.ToDateTime("2013-07-10"),
                            TurmaId = 1,
                        },
                        new Aluno()
                        {
                            Id = 2,
                            Nome = "Carlos Augusto",
                            Cpf = "10203010112",
                            Nascimento = Convert.ToDateTime("2014-08-12"),
                            TurmaId = 1,
                        },
                        new Aluno()
                        {
                            Id = 3,
                            Nome = "Wilter Porto",
                            Cpf = "45672646813",
                            Nascimento = Convert.ToDateTime("2013-05-05"),
                            TurmaId = 2,
                        },
                        new Aluno()
                        {
                            Id = 4,
                            Nome = "Thoru Emanuel",
                            Cpf = "13564134352",
                            Nascimento = Convert.ToDateTime("2010-02-20"),
                            TurmaId = 3,
                        },
                    }
                );

            #endregion
        }
    }
}
