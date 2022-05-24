using SistemaMoedas2.Data;
using SistemaMoedas2.Models;
using SistemaMoedas2.Repositorio.Interface;

namespace SistemaMoedas2.Repositorio.Implementacao
{
    public class VantagemRepositorio : IVantagemRepositorio
    {
        private readonly BancoContext _banco;

        public VantagemRepositorio(BancoContext banco)
        {
            _banco = banco;
        }

        public Vantagem Adicionar(Vantagem vantagem)
        {                
            _banco.Vantagens.Add(vantagem);
            _banco.SaveChanges();
            return vantagem;
        }

        public List<Vantagem> BuscarTodos()
        {
            return _banco.Vantagens.ToList();
        }
    }
}
