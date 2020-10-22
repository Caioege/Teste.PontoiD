using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Teste.Dominio.Models;
using Teste.Infra.Service.Interfaces;
using Teste.Web.Models;

namespace Teste.Web.Controllers
{
    public class EscolaController : Controller
    {
        private IEscolaAppService _escolaAppService;
        private ITurmaAppService _turmaAppService;

        public EscolaController(IEscolaAppService escolaAppService, ITurmaAppService turmaAppService)
        {
            _escolaAppService = escolaAppService;
            _turmaAppService = turmaAppService;
        }

        public IActionResult Escola()
        {
            var escolas = _escolaAppService.GetEscolas();

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
                _escolaAppService.AdicionarEscola(escola);

                TempData["MSG_SUCESSO"] = $"{escola.Nome} adicionada com sucesso!";
                return RedirectToAction(nameof(Escola));
            }

            return View();
        }

        [HttpGet]
        public IActionResult Atualizar(int id)
        {
            var escola = _escolaAppService.GetEscola(id);

            ViewBag.Turmas = _turmaAppService.GetTurmasPorEscola(id);

            return View(escola);
        }

        [HttpPost]
        public IActionResult Atualizar([FromForm] Escola escola)
        {
            if (ModelState.IsValid)
            {
                _escolaAppService.AtualizarEscola(escola);

                TempData["MSG_SUCESSO"] = $"{escola.Nome} atualizada com sucesso!";
                return RedirectToAction(nameof(Escola));
            }

            ViewBag.Turmas = _turmaAppService.GetTurmasPorEscola(escola.Id);

            return View(escola);
        }

        public IActionResult Deletar(int Id)
        {
            var turmas = _turmaAppService.GetTurmasPorEscola(Id);
            if (turmas.Count > 0)
            {
                TempData["MSG_FALHA"] = "Não é possível deletar uma escola que possui turmas vinculadas!";

                return Redirect("/Escola/Atualizar/" + Id);
            }

            _escolaAppService.DeletarEscola(Id);

            TempData["MSG_SUCESSO"] = "Escola deletada com sucesso!";

            return RedirectToAction(nameof(Escola));
        }
    }
}
