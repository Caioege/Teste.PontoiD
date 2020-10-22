using System;
using System.Collections.Generic;
using System.Text;
using Teste.Dominio.Models;

namespace Teste.Infra.Service.Interfaces
{
    public interface IEscolaAppService
    {
        Escola GetEscola(int id);
        List<Escola> GetEscolas();
        void AdicionarEscola(Escola escola);
        void AtualizarEscola(Escola escola);
        void DeletarEscola(int id);
    }
}
