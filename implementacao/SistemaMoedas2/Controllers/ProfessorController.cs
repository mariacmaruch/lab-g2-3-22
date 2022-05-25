using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaMoedas2.Data;
using SistemaMoedas2.Models;
using SistemaMoedas2.Repositorio.Interface;
using System.Text.Json;

namespace SistemaMoedas2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        private readonly IProfessorRepositorio _professor;
        private readonly IContaRepositorio _conta;

        public ProfessorController(IProfessorRepositorio professor, IContaRepositorio conta)
        {
            _professor = professor;
            _conta = conta;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IAsyncEnumerable<Professor>>> GetProfessores()
        {
            try
            {
                var Professores = await _professor.GetAll();
                return Ok(Professores);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
                
            }
        }

        [HttpGet("login")]
        public async Task<ActionResult<Professor>> GetProfessorByEmailAndSenha([FromQuery] string email, [FromQuery] string senha)
        {
            try
            {
                var Professor = await _professor.GetByEmailAndSenha(email, senha);

                if (Professor == null)
                    return NotFound($"Usário ou senha inválidos");

                return Ok(Professor);
            }
            catch
            {
                return BadRequest("Requisição inválida");

            }

        }
        [HttpGet("{id:int}",Name="GetProfessor")]
        public async Task<ActionResult<Professor>> GetProfessor(int id)
        {
            try
            {
                var Professor = await _professor.GetById(id);

                if (Professor == null)
                    return NotFound($"Não existe Professor com o id = {id}");

                return Ok(Professor);
            }
            catch
            {
                return BadRequest("Requisição inválida");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create(Professor professor)
        {
            try
            {
                
                Conta conta = new Conta()
                {
                    Saldo = 1000,
                };
                await _conta.Create(conta);

                professor.ContaId = conta.Id;
                await _professor.Create(professor);

                return CreatedAtRoute(nameof(GetProfessor), new {id = professor.Id }, professor);

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Edit(int id, [FromBody]Professor professor)
        {
            try
            {
                if(professor.Id == id)
                {
                    await _professor.Update(professor);
                    return Ok($"Professor com id = {id} foi atualizado com sucesso");
                }
                else
                {
                    return BadRequest("Dados inconsistentes");
                }

            }
            catch
            {
                return BadRequest("Requisição inválida");
            }
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var Professor = await _professor.GetById(id);
                if(Professor != null)
                {
                    await _professor.Delete(Professor);
                    return Ok($"Professor de id = {id} foi excluido com sucesso");
                }
                else
                {
                    return BadRequest($"Professor de id = {id} não encontrado");
                }

            }
            catch
            {
                return BadRequest("Requisição inválida");
            }
        }
    }
}
