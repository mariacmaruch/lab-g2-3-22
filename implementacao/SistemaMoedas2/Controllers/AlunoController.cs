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
    public class AlunoController : ControllerBase
    {
        private readonly IAlunoRepositorio _aluno;
        private readonly IEnderecoRepositorio _endereco;

        public AlunoController(IAlunoRepositorio aluno, IEnderecoRepositorio endereco)
        {
            _aluno = aluno;
            _endereco = endereco;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IAsyncEnumerable<Aluno>>> GetAlunos()
        {
            try
            {
                var alunos = await _aluno.GetAlunos();
                return Ok(alunos);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
                
            }
        }

        [HttpGet("login")]
        public async Task<ActionResult<Aluno>> GetAlunosByEmailAndSenha([FromQuery] string email, [FromQuery] string senha)
        {
            try
            {
                var aluno = await _aluno.GetAlunoByEmailAndSenha(email, senha);

                if (aluno == null)
                    return NotFound($"Usário ou senha inválidos");

                return Ok(aluno);
            }
            catch
            {
                return BadRequest("Requisição inválida");

            }

        }
        [HttpGet("{id:int}",Name="GetAluno")]
        public async Task<ActionResult<Aluno>> GetAluno(int id)
        {
            try
            {
                var aluno = await _aluno.GetAluno(id);

                if (aluno == null)
                    return NotFound($"Não existe aluno com o id = {id}");

                return Ok(aluno);
            }
            catch
            {
                return BadRequest("Requisição inválida");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create(CadastroAluno aluno)
        {
            Aluno novoAluno = new Aluno()
            {
                Cpf = aluno.Cpf,
                Senha = aluno.Senha,
                Nome = aluno.Nome,
                Email = aluno.Email,
                Rg = aluno.Rg,
                InstituicaoId = aluno.InstituicaoId
            };

            Endereco novoEndereco = new Endereco()
            {
                Rua = aluno.Rua,
                Numero = aluno.Numero,
                Complemento = aluno.Complemento,
                Bairro = aluno.Bairro,
                Cidade = aluno.Cidade,
                Estado = aluno.Estado
            };
            try
            {
                await _aluno.CreateAluno(novoAluno);
                novoEndereco.AlunoId = await _aluno.GetAlunoIdByCpf(novoAluno.Cpf);
                await _endereco.CreateEndereco(novoEndereco);
                return CreatedAtRoute(nameof(GetAluno), new {id = novoAluno.Id }, novoAluno);

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Edit(int id, [FromBody]Aluno aluno)
        {
            try
            {
                if(aluno.Id == id)
                {
                    await _aluno.UpdateAluno(aluno);
                    return Ok($"Aluno com id = {id} foi atualizado com sucesso");
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
                var aluno = await _aluno.GetAluno(id);
                if(aluno != null)
                {
                    await _aluno.DeleteAluno(aluno);
                    return Ok($"Aluno de id = {id} foi excluido com sucesso");
                }
                else
                {
                    return BadRequest($"Aluno de id = {id} não encontrado");
                }

            }
            catch
            {
                return BadRequest("Requisição inválida");
            }
        }
    }
}
