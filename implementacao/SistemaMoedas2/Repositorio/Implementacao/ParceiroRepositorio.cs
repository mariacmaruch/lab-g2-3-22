using Microsoft.EntityFrameworkCore;
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

        public async Task CreateParceiro(Parceiro parceiro)
        {
            _banco.Parceiros.Add(parceiro);
            _banco.SaveChanges();
        }
        public async Task UpdateParceiro(Parceiro parceiro)
        {
            _banco.Entry(parceiro).State = EntityState.Modified;
            await _banco.SaveChangesAsync();
        }

        public async Task DeleteParceiro(Parceiro parceiro)
        {
            _banco.Parceiros.Remove(parceiro);
            await _banco.SaveChangesAsync();
        }
        public async Task<Parceiro> GetParceiro(int id)
        {
            var parceiro = await _banco.Parceiros.FindAsync(id);
            return parceiro;
        }

        public async Task<IEnumerable<Parceiro>> GetParceiros()
        {
            try
            {
                return await _banco.Parceiros.ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<Parceiro> GetParceiroByEmailAndSenha(string email, string senha)
        {
            Parceiro parceiro = null;
            if (!string.IsNullOrWhiteSpace(email) && !string.IsNullOrWhiteSpace(senha))
            {
                parceiro = await _banco.Parceiros.Where(n => n.Email == email && n.Senha == senha).FirstAsync();
            }
            return parceiro;
        }

        public async Task<int> GetParceiroIdByCnpj(string cnpj)
        {
            Parceiro parceiro = null;
            if (!string.IsNullOrWhiteSpace(cnpj))
            {
                parceiro = await _banco.Parceiros.Where(n => n.Cnpj == cnpj).FirstAsync();
            }
            return parceiro.Id;
        }


    }
}
