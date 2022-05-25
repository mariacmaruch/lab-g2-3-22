using SistemaMoedas2.Models;

namespace SistemaMoedas2.Repositorio.Interface
{
    public interface IProfessorRepositorio : IBaseRepositorio<Professor>
    {
        Task<Professor> GetByEmailAndSenha(string email, string senha);
        Task<Professor> GetByCpf(string cpf);
    }
}
