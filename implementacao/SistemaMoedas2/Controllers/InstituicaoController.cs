using Microsoft.AspNetCore.Mvc;
using SistemaMoedas2.Models;
using SistemaMoedas2.Repositorio.Interface;

namespace SistemaMoedas2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstituicaoController : ControllerBase
    {
        private readonly IInstituicaoRepositorio _instituicao;

        public InstituicaoController(IInstituicaoRepositorio instituicao)
        {
            _instituicao = instituicao;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IAsyncEnumerable<Instituicao>>> GetInstituicoes()
        {
            try
            {
                var instituicoes = await _instituicao.GetAll();
                return Ok(instituicoes);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
                
            }
        }
    }
}
