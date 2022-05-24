using Microsoft.AspNetCore.Mvc;

namespace SistemaMoedas2.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}