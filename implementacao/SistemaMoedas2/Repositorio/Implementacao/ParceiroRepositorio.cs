using Microsoft.EntityFrameworkCore;
using SistemaMoedas2.Data;
using SistemaMoedas2.Models;
using SistemaMoedas2.Repositorio.Interface;

namespace SistemaMoedas2.Repositorio.Implementacao
{
    public class ParceiroRepositorio : BaseRepositorio<Parceiro>, IParceiroRepositorio
    {
        public ParceiroRepositorio(BancoContext banco) : base(banco)
        {
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
