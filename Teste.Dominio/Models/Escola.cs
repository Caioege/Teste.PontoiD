using System;
using System.Collections.Generic;
using System.Text;

namespace Teste.Dominio.Models
{
    public class Escola
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Inep { get; set; }

        public List<Turma> Turmas { get; set; }
    }
}
