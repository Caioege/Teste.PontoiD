using Microsoft.EntityFrameworkCore;
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
    public class EscolaRepository : IEscolaRepository
    {
        private readonly PontoiDTesteDb _context;

        public EscolaRepository(PontoiDTesteDb context)
        {
            _context = context;
        }

        public void Add(Escola escola)
        {
            _context.Add(escola);
        }

        public void Update(Escola escola)
        {
            _context.Update(escola);
        }

        public void Delete(int Id)
        {
            var escola = this.Get(Id);
            _context.Remove(escola);
        }

        public Escola Get(int Id)
        {
            return _context.Escola.Find(Id);
        }

        public List<Escola> GetAllEscolas()
        {
            return _context.Escola
                .OrderBy(a => a.Nome)
                .ThenBy(a => a.Inep)
                .ToList();
        }

        public async Task<bool> SaveChangeAsync()
        {
            return (await _context.SaveChangesAsync() > 0);
        }
    }
}
