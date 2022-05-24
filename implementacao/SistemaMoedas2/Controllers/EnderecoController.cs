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
    public class EnderecoController : ControllerBase
    {
        private readonly IEnderecoRepositorio _enderecoRepositorio;

        public EnderecoController(IEnderecoRepositorio enderecoRepositorio)
        {
            _enderecoRepositorio = enderecoRepositorio;
        }

        [HttpGet("{id:int}", Name = "GetEndereco")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Endereco>> GetEndereco(int id)
        {
            try
            {
                var endereco = await _enderecoRepositorio.GetEndereco(id);
                return Ok(endereco);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
                
            }
        }
        [HttpPost]
        public async Task<ActionResult> Create(Endereco endereco)
        {
            try
            {
                await _enderecoRepositorio.CreateEndereco(endereco);
                return CreatedAtRoute(nameof(GetEndereco), new {id = endereco.Id }, endereco);

            }
            catch (Exception ex)
            {
                return BadRequest($"Requisição inválida - {ex.Message}");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Edit(int id, [FromBody]Endereco endereco)
        {
            try
            {
                if(endereco.Id == id)
                {
                    await _enderecoRepositorio.UpdateEndereco(endereco);
                    return Ok($"Endereço com id = {id} foi atualizado com sucesso");
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
                var endereco = await _enderecoRepositorio.GetEndereco(id);
                if(endereco != null)
                {
                    await _enderecoRepositorio.DeleteEndereco(endereco);
                    return Ok($"Endereço de id = {id} foi excluido com sucesso");
                }
                else
                {
                    return BadRequest($"Endereço de id = {id} não encontrado");
                }

            }
            catch
            {
                return BadRequest("Requisição inválida");
            }
        }
    }
}
