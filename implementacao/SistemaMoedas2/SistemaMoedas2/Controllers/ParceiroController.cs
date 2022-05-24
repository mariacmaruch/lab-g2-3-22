using Microsoft.AspNetCore.Mvc;
using SistemaMoedas2.Models;
using SistemaMoedas2.Repositorio.Interface;

namespace SistemaMoedas2.Controllers
{
    public class ParceiroController : Controller
    {
        private readonly IParceiroRepositorio _parceiro;

        public ParceiroController(IParceiroRepositorio aluno)
        {
            _parceiro = aluno;
        }

        public IActionResult Index()
        {
            return View(_parceiro.BuscarTodos());
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

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult HomeParceiro(Parceiro login)
        {
            ViewBag.nomeId = login;
            return View(login);
        }

        /// <summary>
        /// Entrar parceiro
        /// </summary>
        /// <param name="email">Email do parceiro</param>
        /// <param name="senha">Senha do parceiro</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Login(Parceiro parceiro)
        {
            var encontrou = _parceiro.ObterParceiroPorEmailSenha(parceiro.Email, parceiro.Senha);

            if (encontrou == null)
            {
                TempData["Erro"] = $"Email e/ou senha inválidos. Tente novamente.";
                return RedirectToAction("Login");
            }

            var nomeId = _parceiro.ObterPorId(encontrou.Id);
            return RedirectToAction("HomeParceiro", new RouteValueDictionary(nomeId));
        }
    }
}
