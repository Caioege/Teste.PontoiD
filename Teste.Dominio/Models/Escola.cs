using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Teste.Dominio.Models
{
    public class Escola
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo Nome da Escola é obrigatório!")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo Código Inep da Escola é obrigatório!")]
        public int? Inep { get; set; }

        public List<Turma> Turmas { get; set; }
    }
}
