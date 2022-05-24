using Microsoft.EntityFrameworkCore;
using SistemaMoedas2.Data;
using SistemaMoedas2.Models;
using SistemaMoedas2.Repositorio.Interface;

namespace SistemaMoedas2.Repositorio.Implementacao
{
    public class InstituicaoRepositorio : IInstituicaoRepositorio
    {
        private readonly BancoContext _banco;

        public InstituicaoRepositorio(BancoContext banco)
        {
            _banco = banco;
        }
        public async Task<IEnumerable<Instituicao>> GetInstituicoes()
        {
            try
            {
                return await _banco.Instituicao.ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }

        }

    }
}
