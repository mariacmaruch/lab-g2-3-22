using Microsoft.AspNetCore.Mvc;
using SistemaMoedas2.Models;
using SistemaMoedas2.Repositorio.Interface;

namespace SistemaMoedas2.Controllers
{
    public class VantagemController : Controller
    {
        private readonly IVantagemRepositorio _vantagem;

        public VantagemController(IVantagemRepositorio vantagem)
        {
            _vantagem = vantagem;
        }

        public IActionResult Index()
        {
            return View(_vantagem.BuscarTodos());
        }

        public IActionResult Criar()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult Criar(Vantagem vantagem)
        //{
        //    _vantagem.Adicionar(vantagem);
        //    return RedirectToAction("HomeParceiro", "Parceiro");
        //}

        [HttpPost]
        public IActionResult Criar(Vantagem vantagem, IList<IFormFile> arquivos)
        {
            IFormFile imagemCarregada = arquivos.FirstOrDefault();

            if (imagemCarregada != null)
            {
                MemoryStream ms = new MemoryStream();
                imagemCarregada.OpenReadStream().CopyTo(ms);

                Vantagem arqui = new Vantagem()
                {
                    Nome = vantagem.Nome,
                    Custo = vantagem.Custo,
                    Descricao = vantagem.Descricao,
                    Dados = ms.ToArray(),
                    ContentType = imagemCarregada.ContentType
                };

                _vantagem.Adicionar(arqui);
            }
            return RedirectToAction("HomeParceiro", "Parceiro");
        }
    }
}

