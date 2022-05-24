using SistemaMoedas2.Data;
using SistemaMoedas2.Models;
using SistemaMoedas2.Repositorio.Interface;

namespace SistemaMoedas2.Repositorio.Implementacao
{
    public class ProfessorRepositorio : IProfessorRepositorio
    {
        private readonly BancoContext _banco;

        public ProfessorRepositorio(BancoContext banco)
        {
            _banco = banco;
        }

        public Professor ObterProfessorPorEmailSenha(string email, string senha)
        {
            Professor encontrou = _banco.Professor.FirstOrDefault(x => x.Email == email && x.Senha == senha);

            if (encontrou == null)
            {
                return null;
            }

            return encontrou;
        }

        public Professor ObterPorId(int? id)
        {
            return _banco.Professor.FirstOrDefault(x => x.Id == id);
        }
    }
}
