using Microsoft.EntityFrameworkCore;
using SistemaMoedas2.Data;
using SistemaMoedas2.Models;
using SistemaMoedas2.Repositorio.Interface;

namespace SistemaMoedas2.Repositorio.Implementacao
{
    public class ContaRepositorio : BaseRepositorio<Conta>, IContaRepositorio
    {
        public ContaRepositorio(BancoContext banco) : base(banco)
        {
        }

        public async Task<int> CreateReturnId(Conta conta)
        {
            _banco.Set<Conta>().Add(conta);
            _banco.SaveChanges();
            return conta.Id;
        }
    }
}
