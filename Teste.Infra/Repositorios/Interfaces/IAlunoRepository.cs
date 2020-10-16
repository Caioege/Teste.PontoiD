using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Teste.Dominio.Models;

namespace Teste.Infra.Repositorios.Interfaces
{
    public interface IAlunoRepository
    {
        void Add(Aluno aluno);
        void Update(Aluno aluno);
        void Delete(int Id);
        Aluno Get(int Id);
        List<Aluno> GetAllAunos();
        List<Aluno> GetAlunosPorTurma(int turmaId);
        List<Aluno> GetAlunosPorEscola(int escolaId);
        Task<bool> SaveChangeAsync();
    }
}
