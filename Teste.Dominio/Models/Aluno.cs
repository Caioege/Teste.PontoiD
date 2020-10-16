using System;
using System.Collections.Generic;
using System.Text;

namespace Teste.Dominio.Models
{
    public class Aluno
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime Nascimento { get; set; }
        public string Cpf { get; set; }

        public int? TurmaId { get; set; }

        public Turma TurmaAluno { get; set; }
    }
}
