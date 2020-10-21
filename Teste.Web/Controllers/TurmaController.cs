using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Teste.Web.Service;
using Teste.Dominio.Enums;
using Teste.Dominio.Models;

namespace Teste.Web.Controllers
{
    public class TurmaController : Controller
    {
        public IActionResult Turma()
        {
            var turmas = new TurmaAppService().GetTurmas();

            return View(turmas);
        }

        [HttpGet]
        public IActionResult Adicionar()
        {

            ViewBag.Serie = new SelectList(Enum.GetValues(typeof(eSerie)));
            ViewBag.Turno = new SelectList(Enum.GetValues(typeof(eTurno)));

            var escolas = new EscolaAppService().GetEscolas();
            ViewBag.Escolas = escolas.Select(a => new SelectListItem(a.Nome, a.Id.ToString()));

            return View();
        }

        [HttpPost]
        public IActionResult Adicionar([FromForm] Turma turma)
        {
            if(ModelState.IsValid)
            {
                new TurmaAppService().AdicionarTurma(turma);

                return RedirectToAction(nameof(Turma));
            }

            ViewBag.Serie = new SelectList(Enum.GetValues(typeof(eSerie)), turma.Serie);
            ViewBag.Turno = new SelectList(Enum.GetValues(typeof(eTurno)), turma.Turno);

            var escolas = new EscolaAppService().GetEscolas();
            ViewBag.Escolas = escolas.Select(a => new SelectListItem(a.Nome, a.Id.ToString()));

            return View(turma);
        }

        [HttpGet]
        public IActionResult Atualizar(int id)
        {
            var turma = new TurmaAppService().GetTurma(id);

            ViewBag.Serie = new SelectList(Enum.GetValues(typeof(eSerie)), turma.Serie);
            ViewBag.Turno = new SelectList(Enum.GetValues(typeof(eTurno)), turma.Turno);
            ViewBag.Alunos = new AlunoAppService().GetAlunosPorTurma(turma.Id);

            turma.EscolaTurma = new EscolaAppService().GetEscola(turma.EscolaId);
            turma.EscolaId = new EscolaAppService().GetEscola(turma.EscolaId).Id;

            return View(turma);
        }

        [HttpPost]
        public IActionResult Atualizar([FromForm] Turma turma)
        {
            if (ModelState.IsValid)
            {
                new TurmaAppService().AtualizarTurma(turma);

                return RedirectToAction(nameof(Turma));
            }

            ViewBag.Serie = new SelectList(Enum.GetValues(typeof(eSerie)), turma.Serie);
            ViewBag.Turno = new SelectList(Enum.GetValues(typeof(eTurno)), turma.Turno);

            turma.EscolaTurma = new EscolaAppService().GetEscola(turma.EscolaId);
            turma.EscolaId = new EscolaAppService().GetEscola(turma.EscolaId).Id;

            ViewBag.Alunos = new AlunoAppService().GetAlunosPorTurma(turma.Id);

            return View(turma);
        }
    }
}
