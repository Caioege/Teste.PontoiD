using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Teste.Dominio.Models;
using Teste.Infra.DataContext;

namespace Teste.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EscolasController : ControllerBase
    {
        private readonly PontoiDTesteDb _context;

        public EscolasController(PontoiDTesteDb context)
        {
            _context = context;
        }

        // GET: api/Escolas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Escola>>> GetEscola()
        {
            try
            {
                var escolas = await _context.Escola.ToListAsync();

                if (escolas == null)
                {
                    return NotFound("Não foram encontradas escolas cadastradas.");
                }

                return escolas;
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Ops! Houve um erro, tente novamente mais tarde.");
            }

        }

        // GET: api/Escolas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Escola>> GetEscola(int id)
        {
            try
            {
                var escola = await _context.Escola.FindAsync(id);

                if (escola == null)
                {
                    return NotFound("Não foi encontrada escola cadastrada para o código informado.");
                }

                return escola;
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Ops! Houve um erro, tente novamente mais tarde.");
            }
        }

        // PUT: api/Escolas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEscola(int id, Escola escola)
        {

            try
            {
                if (id != escola.Id)
                {
                    return BadRequest();
                }

                _context.Entry(escola).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EscolaExists(id))
                    {
                        return NotFound("Não foi encontrada nenhuma escola com o código informado.");
                    }
                    else
                    {
                        throw;
                    }
                }

                return NoContent();
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Ops! Houve um erro, tente novamente mais tarde.");
            }

        }

        // POST: api/Escolas
        [HttpPost]
        public async Task<ActionResult<Escola>> PostEscola(Escola escola)
        {
            try
            {
                if (escola == null)
                {
                    return NotFound("Os dados da escola não podem estar vazios.");
                }

                _context.Escola.Add(escola);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetEscola", new { id = escola.Id }, escola);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Ops! Houve um erro, tente novamente mais tarde.");
            }

        }

        // DELETE: api/Escolas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Escola>> DeleteEscola(int id)
        {

            try
            {
                var escola = await _context.Escola.FindAsync(id);
                if (escola == null)
                {
                    return NotFound("Não foi encontrada nenhuma escola com o código informado.");
                }

                _context.Escola.Remove(escola);
                await _context.SaveChangesAsync();

                return escola;
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Ops! Houve um erro, tente novamente mais tarde.");
            }

        }

        private bool EscolaExists(int id)
        {
            try
            {
                return _context.Escola.Any(e => e.Id == id);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
