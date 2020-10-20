using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Teste.Dominio.Enums;

namespace Teste.Dominio.Models
{
    public class Turma
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public eSerie Serie { get; set; }
        public eTurno Turno { get; set; }

        public int EscolaId { get; set; }

        [ForeignKey("EscolaId")]
        public Escola EscolaTurma { get; set; }

        public List<Aluno> Alunos { get; set; }
    }
}
