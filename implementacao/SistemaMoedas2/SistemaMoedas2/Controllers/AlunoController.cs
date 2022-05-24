using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaMoedas2.Data;
using SistemaMoedas2.Models;
using SistemaMoedas2.Repositorio.Interface;

namespace SistemaMoedas2.Controllers
{
    public class AlunoController : Controller
    {
        private readonly BancoContext _context;
        private readonly IAlunoRepositorio _aluno;

        public AlunoController(BancoContext context, IAlunoRepositorio aluno)
        {
            _context = context;
            _aluno = aluno;
        }

        public IActionResult Index()
        {
            return View(_aluno.BuscarTodos());
        }

        public IActionResult Criar()
        {
            var list = _context.Instituicao.ToList();
            ViewBag.Instituicao = new SelectList(list, "Id", "Nome");
            return View();
        }

        /// <summary>
        /// Id do aluno para editar
        /// </summary>
        /// <param name="id">id aluno</param>
        /// <returns></returns>
        public IActionResult Editar(int id)
        {
            var list = _context.Instituicao.ToList();
            ViewBag.Instituicao = new SelectList(list, "Id", "Nome");
            var aluno = _aluno.ObterPorId(id);
            return View(aluno);
        }

        // POST: Aluno/Create
        /// <summary>
        /// Cadastrar um aluno
        /// </summary>
        /// <param name="aluno">Model de aluno</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Criar(Aluno aluno)
        {
            var list = _context.Instituicao.ToList();
            ViewBag.Instituicao = new SelectList(list, "Id", "Nome");
            _aluno.Adicionar(aluno);
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Editar um aluno
        /// </summary>
        /// <param name="aluno">Model de aluno</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Editar(Aluno aluno)
        {
            var list = _context.Instituicao.ToList();
            ViewBag.Instituicao = new SelectList(list, "Id", "Nome");
            _aluno.Atualizar(aluno);
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Deletar um aluno
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Apagar(int id)
        {
             _aluno.Deletar(id);
            return RedirectToAction("Index");
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult HomeAluno(Aluno login)
        {
            ViewBag.nomeId = login;
            return View(login);
        }

        /// <summary>
        /// Entrar aluno
        /// </summary>
        /// <param name="email">Email do aluno</param>
        /// <param name="senha">Senha do aluno</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Login(Aluno aluno)
        {
            var encontrou = _aluno.ObterAlunoPorEmailSenha(aluno.Email, aluno.Senha); 

            if (encontrou == null)
            {
                TempData["Erro"] = $"Email e/ou senha inválidos. Tente novamente.";
                return RedirectToAction("Login");
            }

            var nomeId = _aluno.ObterPorId(encontrou.Id);
            return RedirectToAction("HomeAluno", new RouteValueDictionary(nomeId));
        }
    }
}

