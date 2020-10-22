using System;
using System.Collections.Generic;
using System.Text;
using Teste.Dominio.Models;

namespace Teste.Infra.Service.Interfaces
{
    public interface ITurmaAppService
    {
        List<Turma> GetTurmas();
        Turma GetTurma(int id);
        void AdicionarTurma(Turma turma);
        void AtualizarTurma(Turma turma);
        List<Turma> GetTurmasPorEscola(int id);
        void DeletarTurma(int id);
    }
}
