using Microsoft.AspNetCore.Mvc;
using SistemaMoedas2.Models;
using SistemaMoedas2.Repositorio.Interface;

namespace SistemaMoedas2.Controllers
{
    public class ProfessorController : Controller
    {
        private readonly IProfessorRepositorio _professor;

        public ProfessorController(IProfessorRepositorio professor)
        {
            _professor = professor;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult HomeProfessor(Professor login)
        {
            ViewBag.nomeId = login;
            return View(login);
        }

        /// <summary>
        /// Entrar professor
        /// </summary>
        /// <param name="email">Email do professor</param>
        /// <param name="senha">Senha do professor</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Login(Professor professor)
        {
            var encontrou = _professor.ObterProfessorPorEmailSenha(professor.Email, professor.Senha);

            if (encontrou == null)
            {
                TempData["Erro"] = $"Email e/ou senha inválidos. Tente novamente.";
                return RedirectToAction("Login");
            }

            var nomeId = _professor.ObterPorId(encontrou.Id);
            return RedirectToAction("HomeProfessor", new RouteValueDictionary(nomeId));
        }
    }
}
