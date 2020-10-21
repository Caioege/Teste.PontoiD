using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Teste.Dominio.Models;
using Teste.Web.Service;

namespace Teste.Web.Controllers
{
    public class AlunoController : Controller
    {
        public IActionResult Aluno()
        {
            var alunos = new AlunoAppService().GetAlunos();

            return View(alunos);
        }

        [HttpGet]
        public IActionResult Atualizar(int id)
        {
            var aluno = new AlunoAppService().GetAluno(id);

            var turmas = new TurmaAppService().GetTurmas();
            ViewBag.TurmaAluno = turmas.Select(a => new SelectListItem(a.Descricao + " | " + a.EscolaTurma.Nome, a.Id.ToString()));

            return View(aluno);
        }

        [HttpPost]
        public IActionResult Atualizar([FromForm] Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                var data = DateTime.Parse(aluno.Nascimento.ToString()).ToString("yyyy-MM-dd");
                aluno.Nascimento = Convert.ToDateTime(data);

                new AlunoAppService().AtualizarAluno(aluno);

                return RedirectToAction(nameof(Aluno));
            }

            var turmas = new TurmaAppService().GetTurmas();
            ViewBag.TurmaAluno = turmas.Select(a => new SelectListItem(a.Descricao + " | " + a.Turno +  " | " + a.EscolaTurma.Nome, a.Id.ToString()));

            return View(aluno);
        }
    }
}
