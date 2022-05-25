using Microsoft.EntityFrameworkCore;
using SistemaMoedas2.Data;
using SistemaMoedas2.Models;
using SistemaMoedas2.Repositorio.Interface;

namespace SistemaMoedas2.Repositorio.Implementacao
{
    public class InstituicaoRepositorio : BaseRepositorio<Instituicao>, IInstituicaoRepositorio
    {
        public InstituicaoRepositorio(BancoContext banco) : base(banco)
        {
        }

    }
}
