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
        public async Task<ActionResult<IAsyncEnumerable<Parceiro>>> GetInstituicoes()
        {
            try
            {
                var parceiros = await _parceiro.GetParceiros();
                return Ok(parceiros);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);

            }
        }

        [HttpGet("login")]
        public async Task<ActionResult<Parceiro>> GetParceiroByEmailAndSenha([FromQuery] string email, [FromQuery] string senha)
        {
            try
            {
                var parceiro = await _parceiro.GetParceiroByEmailAndSenha(email, senha);

                if (parceiro == null)
                    return NotFound($"Usário ou senha inválidos");

                return Ok(parceiro);
            }
            catch
            {
                return BadRequest("Requisição inválida");

            }

        }

        public IActionResult Criar()
        {
            return View();
        }

        /// <summary>
        /// Id do aluno para editar
        /// </summary>
        /// <param name="id">id aluno</param>
        /// <returns></returns>
        public IActionResult Editar(int id)
        {
            var parceiro = _parceiro.ObterPorId(id);
            return View(parceiro);
        }

        // POST: Aluno/Create
        /// <summary>
        /// Cadastrar um aluno
        /// </summary>
        /// <param name="aluno">Model de aluno</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Criar(Parceiro parceiro)
        {
            _parceiro.Adicionar(parceiro);
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Editar um aluno
        /// </summary>
        /// <param name="parceiro">Model de aluno</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Editar(Parceiro parceiro)
        {
            _parceiro.Atualizar(parceiro);
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Deletar um aluno
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Apagar(int id)
        {
            _parceiro.Deletar(id);
            return RedirectToAction("Index");
        }
    }
}
