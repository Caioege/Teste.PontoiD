using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Teste.Dominio.Models;
using Teste.Infra.DataContext;
using Teste.Infra.Repositorios.Interfaces;

namespace Teste.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurmasController : ControllerBase
    {
        private readonly ITurmaRepository _turmaRepository;

        public TurmasController(ITurmaRepository turmaRepository)
        {
            _turmaRepository = turmaRepository;
        }

        // GET: api/Turmas
        [HttpGet]
        public ActionResult<IEnumerable<Turma>> GetTurma()
        {
            try
            {
                return _turmaRepository.GetAllTurmas();
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Ops! Houve um erro: { ex.Message }.");
            }
        }

        // GET: api/Turmas/5
        [HttpGet("{id}")]
        public ActionResult<Turma> GetTurma(int id)
        {
            try
            {
                var turma = _turmaRepository.Get(id);

                if (turma == null)
                {
                    throw new Exception("Não foi encontrada nenhuma turma para o código informado.");
                }

                return turma;
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Ops! Houve um erro: { ex.Message }.");
            }
        }

        // GET: api/Turmas/getturmaescola/5
        [HttpGet("getturmaescola/{id}")]
        public ActionResult<IEnumerable<Turma>> GetTurmasPorEscola(int id)
        {
            try
            {

                var turmas = _turmaRepository.GetTurmasPorEscola(id);

                if (turmas == null)
                {
                    throw new Exception("Não foi encontrado nenhuma turma para o código informado.");
                }

                return turmas;
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Ops! Houve um erro: { ex.Message }.");
    }
}

        // PUT: api/Turmas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTurma(int id, Turma turma)
        {
            try
            {
                _turmaRepository.Update(turma);

                if (!TurmaExists(id))
                {
                    throw new Exception("A turma que está tentando atualizar não foi encontrada.");
                }

                if (id != turma.Id)
                {
                    throw new Exception("A turma a ser atualizado é diferente do código informado");
                }

                await _turmaRepository.SaveChangeAsync();

                return Ok($"{turma.Descricao} atualizada com sucesso.");

            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Ops! Houve um erro: { ex.Message }.");
            }
        }

        // POST: api/Turmas
        [HttpPost]
        public async Task<ActionResult<Turma>> PostTurma(Turma turma)
        {
            try
            {

                _turmaRepository.Add(turma);
                await _turmaRepository.SaveChangeAsync();

                return CreatedAtAction("GetTurma", new { id = turma.Id }, turma);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Ops! Houve um erro: { ex.Message }.");
            }
        }

        // DELETE: api/Turmas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Turma>> DeleteTurma(int id)
        {
            try
            {

                _turmaRepository.Delete(id);

                var turma = _turmaRepository.Get(id);
                if (turma == null)
                {
                    return NotFound("Turma não encontrada.");
                }

                await _turmaRepository.SaveChangeAsync();

                return Ok($"{turma.Descricao} deletada com sucesso.");
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Ops! Houve um erro: { ex.Message }.");
            }
        }

        private bool TurmaExists(int id)
        {
            var turma = _turmaRepository.Get(id);

            if (turma is null)
            {
                return false; ;
            }

            return true;
        }
    }
}
