using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Teste.Dominio.Models;
using Teste.Web.Models;
using Teste.Web.Service;

namespace Teste.Web.Controllers
{
    public class EscolaController : Controller
    {
        private readonly ILogger<EscolaController> _logger;

        public EscolaController(ILogger<EscolaController> logger)
        {
            _logger = logger;
        }

        public IActionResult Escola()
        {
            var escolas = new EscolaAppService().GetEscolas();

            return View(escolas);
        }

        [HttpGet]
        public IActionResult Adicionar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Adicionar([FromForm] Escola escola)
        {
            if(ModelState.IsValid)
            {
                new EscolaAppService().AdicionarEscola(escola);

                return RedirectToAction(nameof(Escola));
            }

            return View();
        }

        [HttpGet]
        public IActionResult Atualizar(int id)
        {
            var escola = new EscolaAppService().GetEscola(id);

            return View(escola);
        }

        [HttpPost]
        public IActionResult Atualizar([FromForm] Escola escola)
        {
            var esc = new EscolaAppService().AtualizarEscola(escola);

            return RedirectToAction(nameof(Escola));
        }

        public IActionResult Deletar(int Id)
        {
            new EscolaAppService().DeletarEscola(Id);

            return RedirectToAction(nameof(Escola));
        }
    }
}
