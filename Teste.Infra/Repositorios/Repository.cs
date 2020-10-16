using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Teste.Infra.DataContext;
using Teste.Infra.Repositorios.Interfaces;

namespace Teste.Infra.Repositorios
{
    public class Repository : IRepository
    {

        public PontoiDTesteDb _context { get; }

        public Repository(PontoiDTesteDb context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<bool> SaveChangeAsync()
        {
            return (await _context.SaveChangesAsync() > 0);
        }
    }
}
