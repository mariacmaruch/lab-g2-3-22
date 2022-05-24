using SistemaMoedas2.Models;

namespace SistemaMoedas2.Repositorio.Interface
{
    public interface IParceiroRepositorio
    {
        Task<IEnumerable<Parceiro>> GetParceiros();
        Task<Parceiro> GetParceiro(int id);
        Task<Parceiro> GetParceiroByEmailAndSenha(string email, string senha);
        Task<int> GetParceiroIdByCnpj(string cnpj);
        Task CreateParceiro(Parceiro parceiro);
        Task UpdateParceiro(Parceiro parceiro);
        Task DeleteParceiro(Parceiro parceiro);
    }
}
