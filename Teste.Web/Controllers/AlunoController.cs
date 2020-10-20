using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
    }
}
