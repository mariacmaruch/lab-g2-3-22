using Microsoft.EntityFrameworkCore;
using SistemaMoedas2.Data;
using SistemaMoedas2.Models;
using SistemaMoedas2.Repositorio.Interface;

namespace SistemaMoedas2.Repositorio.Implementacao
{
    public class AlunoRepositorio : BaseRepositorio<Aluno>, IAlunoRepositorio
    {
        public AlunoRepositorio(BancoContext banco) : base(banco)
        {
        }

        public async Task<Aluno> GetAlunoByEmailAndSenha(string email, string senha)
        {
            Aluno aluno = null;
            if (!string.IsNullOrWhiteSpace(email) && !string.IsNullOrWhiteSpace(senha))
            {
                aluno = await _banco.Alunos.Where(n => n.Email == email && n.Senha == senha).FirstAsync();
            }
            return aluno;
        }

        public async Task<int> GetAlunoIdByCpf(string cpf)
        {
            Aluno aluno = null;
            if (!string.IsNullOrWhiteSpace(cpf))
            {
                aluno = await _banco.Alunos.Where(n => n.Cpf == cpf).FirstAsync();
            }
            return aluno.Id;
        }


    }
}
