using Microsoft.AspNetCore.Mvc;
using SistemaMoedas2.Data;
using SistemaMoedas2.Models;
using SistemaMoedas2.Repositorio.Interface;

namespace SistemaMoedas2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParceiroController : ControllerBase
    {
        private readonly IParceiroRepositorio _parceiro;

        public ParceiroController(IParceiroRepositorio parceiro)
        {
            _parceiro = parceiro;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IAsyncEnumerable<Parceiro>>> GetParceiros()
        {
            try
            {
                var parceiros = await _parceiro.GetAll();
                return Ok(parceiros);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);

            }
        }
        [HttpGet("{id:int}", Name = "GetParceiro")]
        public async Task<ActionResult<Aluno>> GetParceiro(int id)
        {
            try
            {
                var parceiro = await _parceiro.GetById(id);

                if (parceiro == null)
                    return NotFound($"Não existe parceiro com o id = {id}");

                return Ok(parceiro);
            }
            catch
            {
                return BadRequest("Requisição inválida");
            }
        }

        [HttpGet("login")]
        public async Task<ActionResult<Parceiro>> GetParceiroByEmailAndSenha([FromQuery] string email, [FromQuery] string senha)
        {
            try
            {
                var parceiro = await _parceiro.GetParceiroByEmailAndSenha(email, senha);

                if (parceiro == null)
                    return NotFound($"Usuário ou senha inválidos");

                return Ok(parceiro);
            }
            catch
            {
                return BadRequest("Requisição inválida");

            }

        }
        [HttpPost]
        public async Task<ActionResult> Create(Parceiro parceiro)
        {
            try
            {
                await _parceiro.Create(parceiro);
                return CreatedAtRoute(nameof(GetParceiro), new { id = parceiro.Id }, parceiro);
            }
            catch
            {

                return BadRequest("Requisição inválida"); ;
            }
            
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Edit(int id, [FromBody] Parceiro parceiro)
        {
            try
            {
                if (parceiro.Id == id)
                {
                    await _parceiro.Update(parceiro);
                    return Ok($"Parceiro com id = {id} foi atualizado com sucesso");
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
                var parceiro = await _parceiro.GetById(id);
                if (parceiro != null)
                {
                    await _parceiro.Delete(parceiro);
                    return Ok($"Parceiro de id = {id} foi excluido com sucesso");
                }
                else
                {
                    return BadRequest($"Parceiro de id = {id} não encontrado");
                }

            }
            catch
            {
                return BadRequest("Requisição inválida");
            }
        }
    }
}
