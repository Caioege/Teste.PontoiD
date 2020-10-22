using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Teste.Dominio.Enums;
using Teste.Dominio.Models;
using Teste.Infra.Service.Interfaces;

namespace Teste.Web.Controllers
{
    public class TurmaController : Controller
    {

        private ITurmaAppService _turmaAppService;
        private IEscolaAppService _escolaAppService;
        private IAlunoAppService _alunoAppService;

        public TurmaController(ITurmaAppService turmaAppService, IEscolaAppService escolaAppService, IAlunoAppService alunoAppService)
        {
            _turmaAppService = turmaAppService;
            _escolaAppService = escolaAppService;
            _alunoAppService = alunoAppService;
        }

        public IActionResult Turma()
        {
            var turmas = _turmaAppService.GetTurmas();

            return View(turmas);
        }

        [HttpGet]
        public IActionResult Adicionar()
        {

            ViewBag.Serie = new SelectList(Enum.GetValues(typeof(eSerie)));
            ViewBag.Turno = new SelectList(Enum.GetValues(typeof(eTurno)));

            var escolas = _escolaAppService.GetEscolas();
            ViewBag.Escolas = escolas.Select(a => new SelectListItem(a.Nome, a.Id.ToString()));

            return View();
        }

        [HttpPost]
        public IActionResult Adicionar([FromForm] Turma turma)
        {
            if (ModelState.IsValid)
            {
                _turmaAppService.AdicionarTurma(turma);

                TempData["MSG_SUCESSO"] = $"{turma.Descricao} adicionada com sucesso!";

                return RedirectToAction(nameof(Turma));
            }

            ViewBag.Serie = new SelectList(Enum.GetValues(typeof(eSerie)), turma.Serie);
            ViewBag.Turno = new SelectList(Enum.GetValues(typeof(eTurno)), turma.Turno);

            var escolas = _escolaAppService.GetEscolas();
            ViewBag.Escolas = escolas.Select(a => new SelectListItem(a.Nome, a.Id.ToString()));

            return View(turma);
        }

        [HttpGet]
        public IActionResult Atualizar(int id)
        {
            var turma = _turmaAppService.GetTurma(id);

            ViewBag.Serie = new SelectList(Enum.GetValues(typeof(eSerie)), turma.Serie);
            ViewBag.Turno = new SelectList(Enum.GetValues(typeof(eTurno)), turma.Turno);
            ViewBag.Alunos = _alunoAppService.GetAlunosPorTurma(turma.Id);

            turma.EscolaTurma = _escolaAppService.GetEscola(turma.EscolaId);
            turma.EscolaId = _escolaAppService.GetEscola(turma.EscolaId).Id;

            return View(turma);
        }

        [HttpPost]
        public IActionResult Atualizar([FromForm] Turma turma)
        {
            if (ModelState.IsValid)
            {
                _turmaAppService.AtualizarTurma(turma);

                TempData["MSG_SUCESSO"] = $"{turma.Descricao} atualizada com sucesso!";

                return RedirectToAction(nameof(Turma));
            }

            ViewBag.Serie = new SelectList(Enum.GetValues(typeof(eSerie)), turma.Serie);
            ViewBag.Turno = new SelectList(Enum.GetValues(typeof(eTurno)), turma.Turno);

            turma.EscolaTurma = _escolaAppService.GetEscola(turma.EscolaId);
            turma.EscolaId = _escolaAppService.GetEscola(turma.EscolaId).Id;

            ViewBag.Alunos = _alunoAppService.GetAlunosPorTurma(turma.Id);

            return View(turma);
        }

        [HttpGet]
        public IActionResult Deletar(int id)
        {
            var alunos = _alunoAppService.GetAlunosPorTurma(id);
            if (alunos.Count > 0)
            {
                TempData["MSG_FALHA"] = "Não é possível deletar uma turma que possui alunos vinculados!";

                return Redirect("/Turma/Atualizar/" + id);
            }

            _turmaAppService.DeletarTurma(id);

            TempData["MSG_SUCESSO"] = "Turma deletada com sucesso!";

            return RedirectToAction(nameof(Turma));
        }
    }
}
