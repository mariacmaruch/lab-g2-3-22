using Microsoft.EntityFrameworkCore;
using SistemaMoedas2.Data;
using SistemaMoedas2.Models;
using SistemaMoedas2.Repositorio.Interface;

namespace SistemaMoedas2.Repositorio.Implementacao
{
    public class ProfessorRepositorio : BaseRepositorio<Professor>, IProfessorRepositorio
    {
        public ProfessorRepositorio(BancoContext banco) : base(banco)
        {
        }

        public async Task<Professor> GetByEmailAndSenha(string email, string senha)
        {
            Professor professor = null;
            if (!string.IsNullOrWhiteSpace(email) && !string.IsNullOrWhiteSpace(senha))
            {
                professor = await _banco.Professores.Where(n => n.Email == email && n.Senha == senha).FirstAsync();
            }
            return professor;
        }

        public async Task<Professor> GetByCpf(string cpf)
        {
            Professor professor = null;
            if (!string.IsNullOrWhiteSpace(cpf))
            {
                professor = await _banco.Professores.Where(n => n.Cpf == cpf).FirstAsync();
            }
            return professor;
        }


    }
}
