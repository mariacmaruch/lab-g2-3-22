using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using SistemaMoedas2.Models;
using SistemaMoedas2.Repositorio.Interface;

namespace SistemaMoedas2.Controllers
{
    public class VantagemController : Controller
    {
        private readonly IVantagemRepositorio _vantagem;
        private readonly IWebHostEnvironment _appEnvironment;

        public VantagemController(IVantagemRepositorio vantagem, IWebHostEnvironment appEnvironment)
        {
            _vantagem = vantagem;
            _appEnvironment = appEnvironment;
        }

        public IActionResult Index()
        {
            return View(_vantagem.BuscarTodos());
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(Vantagem vantagem, IList<IFormFile> arquivos)
        {
            IFormFile imagemCarregada = arquivos.FirstOrDefault();
            string uniqueFileName; 

            if (imagemCarregada != null)
            {
                MemoryStream ms = new MemoryStream();

                string uploadsFolder = Path.Combine(_appEnvironment.WebRootPath, "images");
                uniqueFileName = imagemCarregada.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    imagemCarregada.CopyTo(fileStream);
                }

                Vantagem arqui = new Vantagem()
                {
                    Nome = vantagem.Nome,
                    Custo = vantagem.Custo,
                    Descricao = vantagem.Descricao,
                    Dados = ms.ToArray(),
                    ContentType = uniqueFileName
                };

                _vantagem.Adicionar(arqui);
            }
            return RedirectToAction("HomeParceiro", "Parceiro");
        }
    }
}



