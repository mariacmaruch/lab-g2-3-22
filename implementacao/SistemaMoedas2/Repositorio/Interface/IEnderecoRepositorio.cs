using SistemaMoedas2.Models;

namespace SistemaMoedas2.Repositorio.Interface
{
    public interface IEnderecoRepositorio
    {
        Task<Endereco> GetEndereco(int id);
        Task CreateEndereco(Endereco endereco);
        Task UpdateEndereco(Endereco endereco);
        Task DeleteEndereco(Endereco endereco);
    }
}
