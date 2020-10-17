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
    public class TurmaRepository : ITurmaRepository
    {
        private readonly PontoiDTesteDb _context;

        public TurmaRepository(PontoiDTesteDb context)
        {
            _context = context;
        }

        public void Add(Turma turma)
        {
            _context.Add(turma);
        }

        public void Update(Turma turma)
        {
            _context.Update(turma);
        }

        public void Delete(int Id)
        {
            var turma = this.Get(Id);
            _context.Remove(turma);
        }

        public Turma Get(int Id)
        {
            return _context.Turma.Find(Id);
        }

        public List<Turma> GetAllTurmas()
        {
            return _context.Turma
                .OrderBy(a => a.Descricao)
                .ThenBy(a => a.EscolaId)
                .ToList();
        }

        public List<Turma> GetTurmasPorEscola(int escolaId)
        {
            return _context.Turma.Where(c => c.EscolaId == escolaId).ToList();
        }

        public async Task<bool> SaveChangeAsync()
        {
            return (await _context.SaveChangesAsync() > 0);
        }
    }
}
