using System;
using System.Collections.Generic;
using System.Text;
using Teste.Dominio.Models;

namespace Teste.Infra.Service.Interfaces
{
    public interface IAlunoAppService
    {
        List<Aluno> GetAlunos();
        Aluno GetAluno(int id);
        void AdicionarAluno(Aluno aluno);
        List<Aluno> GetAlunosPorTurma(int id);
        void AtualizarAluno(Aluno aluno);
        void DeletarAluno(int id);
    }
}
