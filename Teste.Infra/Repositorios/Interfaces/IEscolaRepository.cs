using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Teste.Dominio.Models;

namespace Teste.Infra.Repositorios.Interfaces
{
    public interface IEscolaRepository
    {
        void Add(Escola escola);
        void Update(Escola escola);
        void Delete(int Id);
        Escola Get(int Id);
        List<Escola> GetAllEscolas();
        Task<bool> SaveChangeAsync();
    }
}
