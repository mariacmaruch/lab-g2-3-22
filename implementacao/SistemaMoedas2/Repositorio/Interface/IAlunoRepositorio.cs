using SistemaMoedas2.Models;

namespace SistemaMoedas2.Repositorio.Interface
{
    public interface IAlunoRepositorio : IBaseRepositorio<Aluno>
    {
        Task<Aluno> GetAlunoByEmailAndSenha(string email, string senha);
        Task<int> GetAlunoIdByCpf(string cpf);
    }
}
