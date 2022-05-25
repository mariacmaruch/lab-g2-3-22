using SistemaMoedas2.Models;

namespace SistemaMoedas2.Repositorio.Interface
{
    public interface IContaRepositorio : IBaseRepositorio<Conta>
    {
        Task<int> CreateReturnId(Conta conta);
    }
}
