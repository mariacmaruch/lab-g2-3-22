using SistemaMoedas2.Models;

namespace SistemaMoedas2.Repositorio.Interface
{
    public interface IInstituicaoRepositorio
    {
        Task<IEnumerable<Instituicao>> GetInstituicoes();
    }
}
