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
    public class AlunosController : ControllerBase
    {
        private readonly IAlunoRepository _alunoRepository;

        public AlunosController(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

        // GET: api/Alunos
        [HttpGet]
        public ActionResult<IEnumerable<Aluno>> GetAluno()
        {

            try
            {
                return _alunoRepository.GetAllAunos();
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Ops! Houve um erro: { ex }.");
            }
            
        }

        // GET: api/Alunos/getalunoturma/5
        [HttpGet("getalunoturma/{id}")]
        public ActionResult<IEnumerable<Aluno>> GetAlunosPorTurma(int id)
        {

            try
            {

                var alunos = _alunoRepository.GetAlunosPorTurma(id);

                if (alunos == null)
                {
                    throw new Exception("Não foi encontrado nenhum aluno para o código informado.");
                }

                return alunos;
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Ops! Houve um erro: { ex }.");
            }
            
        }

        // GET: api/Alunos/getalunoescola/5
        [HttpGet("getalunoescola/{id}")]
        public ActionResult<IEnumerable<Aluno>> GetAlunosPorEscola(int id)
        {
            try
            {

                var alunos = _alunoRepository.GetAlunosPorEscola(id);

                if (alunos is null)
                {
                    throw new Exception("Não foi encontrado nenhum aluno para o código informado.");
                }

                return alunos;
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Ops! Houve um erro: { ex }.");
            }
        }

        // GET: api/Alunos/5
        [HttpGet("{id}")]
        public ActionResult<Aluno> GetAluno(int id)
        {
            try
            {
                var aluno = _alunoRepository.Get(id);

                if (aluno == null)
                {
                    throw new Exception("Não foi encontrado nenhum aluno para o código informado.");
                }

                return aluno;
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Ops! Houve um erro: { ex }.");
            }
            
        }

        // PUT: api/Alunos/5
        [HttpPut("{id}")]
        public ActionResult PutAluno(int id, Aluno aluno)
        {

            try
            {
                _alunoRepository.Update(aluno);

                if (!AlunoExists(id))
                {
                    throw new Exception("O aluno que está tentando atualizar não foi encontrado.");
                }

                if (id != aluno.Id)
                {
                    throw new Exception("O aluno a ser atualizado é diferente do código informado");
                }

                _alunoRepository.SaveChangeAsync();

                return Ok($"{aluno.Nome} atualizado com sucesso.");

            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Ops! Houve um erro: { ex }.");
            }
        }

        // POST: api/Alunos
        [HttpPost]
        public async Task<ActionResult> PostAluno(Aluno aluno)
        {

            try
            {

                _alunoRepository.Add(aluno);

                if (!await _alunoRepository.SaveChangeAsync())
                {
                    return NotFound("Não foi possível adicionar o aluno informado, verifique os dados e tente novamente.");
                }

                return CreatedAtAction("GetAluno", new { id = aluno.Id }, aluno);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Ops! Houve um erro: { ex }.");
            }
            
        }

        // DELETE: api/Alunos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Aluno>> DeleteAluno(int id)
        {
            try
            {
                var aluno = _alunoRepository.Get(id);
                if (aluno == null)
                {
                    return NotFound("Aluno não encontrado.");
                }

                _alunoRepository.Delete(id);
                await _alunoRepository.SaveChangeAsync();

                return Ok($"{aluno.Nome} deletado com sucesso.");
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Ops! Houve um erro: { ex }.");
            }

        }

        private bool AlunoExists(int id)
        {
            var aluno = _alunoRepository.Get(id);

            if (aluno is null)
            {
                return false; ;
            }

            return true;
        }
    }
}
