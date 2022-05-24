using Microsoft.EntityFrameworkCore;
using SistemaMoedas2.Data;
using SistemaMoedas2.Models;
using SistemaMoedas2.Repositorio.Interface;

namespace SistemaMoedas2.Repositorio.Implementacao
{
    public class AlunoRepositorio : IAlunoRepositorio
    {
        private readonly BancoContext _banco;

        public AlunoRepositorio(BancoContext banco)
        {
            _banco = banco;
        }
        public async Task CreateAluno(Aluno aluno)
        {
            _banco.Alunos.Add(aluno);
            _banco.SaveChanges();
        }
        public async Task UpdateAluno(Aluno aluno)
        {
            _banco.Entry(aluno).State = EntityState.Modified;
            await _banco.SaveChangesAsync();
        }

        public async Task DeleteAluno(Aluno aluno)
        {
            _banco.Alunos.Remove(aluno);
            await _banco.SaveChangesAsync();
        }
        public async Task<Aluno> GetAluno(int id)
        {
            var aluno = await _banco.Alunos.FindAsync(id);
            return aluno;
        }

        public async Task<IEnumerable<Aluno>> GetAlunos()
        {
            try
            {
                return await _banco.Alunos.ToListAsync();
            }
            catch (Exception)
            {

                throw;
           }
            
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
