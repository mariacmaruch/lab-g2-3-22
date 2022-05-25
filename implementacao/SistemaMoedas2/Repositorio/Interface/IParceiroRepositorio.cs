using SistemaMoedas2.Models;

namespace SistemaMoedas2.Repositorio.Interface
{
    public interface IParceiroRepositorio : IBaseRepositorio<Parceiro>
    {
        Task<Parceiro> GetParceiroByEmailAndSenha(string email, string senha);
        Task<int> GetParceiroIdByCnpj(string cnpj);
    }
}
