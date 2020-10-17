using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Teste.Dominio.Models;

namespace Teste.Infra.Repositorios.Interfaces
{
    public interface ITurmaRepository
    {
        void Add(Turma turma);
        void Update(Turma turma);
        void Delete(int Id);
        Turma Get(int Id);
        List<Turma> GetAllTurmas();
        List<Turma> GetTurmasPorEscola(int escolaId);
        Task<bool> SaveChangeAsync();
    }
}
