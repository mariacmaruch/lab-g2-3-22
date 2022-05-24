using SistemaMoedas2.Data;
using SistemaMoedas2.Models;
using SistemaMoedas2.Repositorio.Interface;

namespace SistemaMoedas2.Repositorio.Implementacao
{
    public class ParceiroRepositorio : IParceiroRepositorio
    {
        private readonly BancoContext _banco;

        public ParceiroRepositorio(BancoContext banco)
        {
            _banco = banco;
        }

        public Parceiro Adicionar(Parceiro parceiro)
        {
            _banco.Parceiros.Add(parceiro);
            _banco.SaveChanges();
            return parceiro;
        }

        public Parceiro Atualizar(Parceiro parceiro)
        {
            Parceiro parceiroDb = ObterPorId(parceiro.Id);
            if(parceiroDb == null)
            {
                throw new System.Exception("Parceiro não encontrado.");         
            }

            parceiroDb.Nome = parceiro.Nome;
            parceiroDb.Email = parceiro.Email;
            parceiroDb.Senha = parceiro.Senha;
            parceiroDb.Cnpj = parceiro.Cnpj;

            _banco.Parceiros.Update(parceiroDb);
            _banco.SaveChanges();

            return parceiroDb; 
        }

        public List<Parceiro> BuscarTodos()
        {
            return _banco.Parceiros.ToList();
        }

        public bool Deletar(int? id)
        {
            Parceiro parceiroDb = ObterPorId(id);
            if (parceiroDb == null)
            {
                throw new System.Exception("Aluno não encontrado.");
            }

            _banco.Parceiros.Remove(parceiroDb);
            _banco.SaveChanges();
            return true;
        }

        public Parceiro ObterPorId(int? id)
        {
            return _banco.Parceiros.FirstOrDefault(x => x.Id == id);
        }
    }
}
