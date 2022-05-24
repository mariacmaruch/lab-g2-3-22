using SistemaMoedas2.Models;

namespace SistemaMoedas2.Repositorio.Interface
{
    public interface IVantagemRepositorio
    {
        List<Vantagem> BuscarTodos();
        Vantagem Adicionar(Vantagem vantagem);
    }
}
