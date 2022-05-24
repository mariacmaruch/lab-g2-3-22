using SistemaMoedas2.Models;

namespace SistemaMoedas2.Repositorio.Interface
{
    public interface IAlunoRepositorio
    {
        List<Aluno> BuscarTodos();
        Aluno Adicionar(Aluno aluno);
        Aluno ObterPorId(int? id);
        Aluno Atualizar(Aluno aluno);
        bool Deletar(int? id);
        Aluno ObterAlunoPorEmailSenha(string email, string senha);
        //bool EnviarMoedas(int? idConta, int quantidade);
    }
}
