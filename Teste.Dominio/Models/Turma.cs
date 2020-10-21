using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Teste.Dominio.Enums;

namespace Teste.Dominio.Models
{
    public class Turma
    {
        public int Id { get; set; }
        [Required(ErrorMessage= "O campo Descricao é obrigatório!")]
        [MinLength(3, ErrorMessage="O campo descrição deve conter pelo menos 3 caracteres.")]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "O campo Serie é obrigatório!")]
        public eSerie Serie { get; set; }
        [Required(ErrorMessage = "O campo Turno é obrigatório!")]
        public eTurno Turno { get; set; }

        public int EscolaId { get; set; }

        [ForeignKey("EscolaId")]
        public Escola EscolaTurma { get; set; }

        public List<Aluno> Alunos { get; set; }
    }
}
