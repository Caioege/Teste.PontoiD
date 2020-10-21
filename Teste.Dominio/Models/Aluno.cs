using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Teste.Dominio.Models
{
    public class Aluno
    {
        public int Id { get; set; }
        [Required(ErrorMessage="O campo Nome é obrigatório!")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo Nascimento é obrigatório!")]
        public DateTime Nascimento { get; set; }
        [Required(ErrorMessage = "O campo Cpf é obrigatório!")]
        public string Cpf { get; set; }

        public int? TurmaId { get; set; }

        public Turma TurmaAluno { get; set; }
    }
}
