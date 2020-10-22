using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Teste.Dominio.Models;
using Teste.Infra.Service.Interfaces;

namespace Teste.Web.Controllers
{
    public class AlunoController : Controller
    {
        private ITurmaAppService _turmaAppService;
        private IAlunoAppService _alunoAppService;

        public AlunoController(ITurmaAppService turmaAppService, IAlunoAppService alunoAppService)
        {
            _turmaAppService = turmaAppService;
            _alunoAppService = alunoAppService;
        }

        public IActionResult Aluno()
        {
            var alunos = _alunoAppService.GetAlunos();

            return View(alunos);
        }

        [HttpGet]
        public IActionResult Adicionar()
        {
            var turmas = _turmaAppService.GetTurmas();
            ViewBag.TurmaAluno = turmas.Select(a => new SelectListItem(a.Descricao + " | " + a.Turno.ToString() + " | " + a.EscolaTurma.Nome, a.Id.ToString()));

            return View();
        }

        [HttpPost]
        public IActionResult Adicionar([FromForm] Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                _alunoAppService.AdicionarAluno(aluno);

                TempData["MSG_SUCESSO"] = $"{aluno.Nome} adicionado(a) com sucesso!";

                return RedirectToAction(nameof(Aluno));
            }

            var turmas = _turmaAppService.GetTurmas();
            ViewBag.TurmaAluno = turmas.Select(a => new SelectListItem(a.Descricao + " | " + a.Turno.ToString() + " | " + a.EscolaTurma.Nome, a.Id.ToString()));

            return View(aluno);
        }

        [HttpGet]
        public IActionResult Atualizar(int id)
        {
            var aluno = _alunoAppService.GetAluno(id);

            var turmas = _turmaAppService.GetTurmas();
            ViewBag.TurmaAluno = turmas.Select(a => new SelectListItem(a.Descricao + " | " + a.Turno.ToString() + " | " + a.EscolaTurma.Nome, a.Id.ToString()));

            return View(aluno);
        }

        [HttpPost]
        public IActionResult Atualizar([FromForm] Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                _alunoAppService.AtualizarAluno(aluno);

                TempData["MSG_SUCESSO"] = $"{aluno.Nome} atualizado(a) com sucesso!";

                return RedirectToAction(nameof(Aluno));
            }

            var turmas = _turmaAppService.GetTurmas();
            ViewBag.TurmaAluno = turmas.Select(a => new SelectListItem(a.Descricao + " | " + a.Turno.ToString() +  " | " + a.EscolaTurma.Nome, a.Id.ToString()));

            return View(aluno);
        }

        [HttpGet]
        public IActionResult Deletar(int id)
        {
            _alunoAppService.DeletarAluno(id);

            TempData["MSG_SUCESSO"] = "Aluno deletado com sucesso!";

            return RedirectToAction(nameof(Aluno));
        }
    }
}
