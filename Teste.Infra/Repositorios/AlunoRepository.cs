using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste.Dominio.Models;
using Teste.Infra.DataContext;
using Teste.Infra.Repositorios.Interfaces;

namespace Teste.Infra.Repositorios
{
    public class AlunoRepository : IAlunoRepository
    {
        private readonly PontoiDTesteDb _context;

        public AlunoRepository(PontoiDTesteDb context)
        {
            _context = context;
        }

        public void Add(Aluno aluno)
        {
            _context.Add(aluno);
        }

        public void Update(Aluno aluno)
        {
            _context.Update(aluno);
        }

        public void Delete(int Id)
        {
            var aluno = this.Get(Id);
            _context.Remove(aluno);
        }

        public Aluno Get(int Id)
        {
            return _context.Aluno.Find(Id);
        }

        public List<Aluno> GetAllAunos()
        {
            return _context.Aluno
                .Include(a => a.TurmaAluno)
                .OrderBy(a => a.Nome)
                .ThenBy(a => a.TurmaAluno.EscolaId)
                .ToList();
        }

        public List<Aluno> GetAlunosPorTurma(int turmaId)
        {
            return _context.Aluno.Where(c => c.TurmaAluno.Id == turmaId).ToList();
            
        }

        public List<Aluno> GetAlunosPorEscola(int escolaId)
        {
            return _context.Aluno.Where(c => c.TurmaAluno.EscolaId == escolaId).ToList();

        }

        public async Task<bool> SaveChangeAsync()
        {
            return (await _context.SaveChangesAsync() > 0);
        }
        
    }
}
