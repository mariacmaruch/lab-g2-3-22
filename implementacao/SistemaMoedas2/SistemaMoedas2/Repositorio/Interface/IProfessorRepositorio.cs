using SistemaMoedas2.Models;

namespace SistemaMoedas2.Repositorio.Interface
{
    public interface IProfessorRepositorio
    {
        Professor ObterProfessorPorEmailSenha(string email, string senha);
        Professor ObterPorId(int? id);
    }
}
