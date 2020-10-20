using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Teste.Web.Service;

namespace Teste.Web.Controllers
{
    public class TurmaController : Controller
    {
        public IActionResult Turma()
        {
            var turmas = new TurmaAppService().GetTurmas();

            return View(turmas);
        }
    }
}
