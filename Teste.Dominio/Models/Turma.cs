using System;
using System.Collections.Generic;
using System.Text;

namespace Teste.Dominio.Models
{
    public class Turma
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int Serie { get; set; }
        public int Turno { get; set; }

        public int EscolaId { get; set; }

        public Escola EscolaTurma { get; set; }

        public List<Aluno> Alunos { get; set; }
    }
}
