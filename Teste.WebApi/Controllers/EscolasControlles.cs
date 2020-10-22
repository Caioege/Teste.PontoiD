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
    public class EscolasController : ControllerBase
    {
        private readonly IEscolaRepository _escolaRepository;

        public EscolasController(IEscolaRepository escolaRepository)
        {
            _escolaRepository = escolaRepository;
        }

        // GET: api/Escolas
        [HttpGet]
        public ActionResult<IEnumerable<Escola>> GetEscola()
        {
            try
            {
                return _escolaRepository.GetAllEscolas();
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Ops! Houve um erro: { ex.Message }.");
            }

        }

        // GET: api/Escolas/5
        [HttpGet("{id}")]
        public ActionResult<Escola> GetEscola(int id)
        {
            try
            {
                var escola = _escolaRepository.Get(id);

                if (escola == null)
                {
                    throw new Exception("Não foi encontrada nenhuma escola para o código informado.");
                }

                return escola;
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Ops! Houve um erro: { ex.Message }.");
            }
        }

        // PUT: api/Escolas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEscola(int id, Escola escola)
        {

            try
            {
                _escolaRepository.Update(escola);

                if (!EscolaExists(id))
                {
                    throw new Exception("A escola que está tentando atualizar não foi encontrada.");
                }

                if (id != escola.Id)
                {
                    throw new Exception("A turma a ser atualizado é diferente do código informado");
                }

                await _escolaRepository.SaveChangeAsync();

                return Ok($"{escola.Nome} atualizada com sucesso.");

            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Ops! Houve um erro: { ex.Message }.");
            }

        }

        // POST: api/Escolas
        [HttpPost]
        public async Task<ActionResult<Escola>> PostEscola(Escola escola)
        {
            try
            {
                _escolaRepository.Add(escola);
                await _escolaRepository.SaveChangeAsync();

                return CreatedAtAction("GetTurma", new { id = escola.Id }, escola);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Ops! Houve um erro: { ex.Message }.");
            }

        }

        // DELETE: api/Escolas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Escola>> DeleteEscola(int id)
        {

            try
            {
                _escolaRepository.Delete(id);

                var escola = _escolaRepository.Get(id);
                if (escola == null)
                {
                    return NotFound("Escola não encontrada.");
                }

                await _escolaRepository.SaveChangeAsync();

                return Ok($"{escola.Nome} deletada com sucesso.");
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Ops! Houve um erro: { ex.Message }.");
            }

        }

        private bool EscolaExists(int id)
        {
            var turma = _escolaRepository.Get(id);

            if (turma is null)
            {
                return false; ;
            }

            return true;
        }
    }
}
