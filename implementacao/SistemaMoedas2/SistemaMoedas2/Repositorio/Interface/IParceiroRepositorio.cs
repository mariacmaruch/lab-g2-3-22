using SistemaMoedas2.Models;

namespace SistemaMoedas2.Repositorio.Interface
{
    public interface IParceiroRepositorio
    {
        List<Parceiro> BuscarTodos();
        Parceiro Adicionar(Parceiro aluno);
        Parceiro ObterPorId(int? id);
        Parceiro Atualizar(Parceiro aluno);
        bool Deletar(int? id);
    }
}
