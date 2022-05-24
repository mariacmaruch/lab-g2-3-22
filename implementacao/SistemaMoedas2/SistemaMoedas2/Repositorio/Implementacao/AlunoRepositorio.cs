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

        public Aluno Adicionar(Aluno aluno)
        {
            _banco.Alunos.Add(aluno);
            _banco.SaveChanges();
            return aluno;
        }

        public Aluno Atualizar(Aluno aluno)
        {
            Aluno alunoDb = ObterPorId(aluno.Id);
            if(alunoDb == null)
            {
                throw new System.Exception("Aluno não encontrado.");         
            }

            alunoDb.Nome = aluno.Nome;
            alunoDb.Email = aluno.Email;
            alunoDb.Senha = aluno.Senha;
            alunoDb.Cpf = aluno.Cpf;
            alunoDb.Rg = aluno.Rg;
            alunoDb.InstituicaoId = aluno.InstituicaoId;
            alunoDb.Endereco = aluno.Endereco;

            _banco.Alunos.Update(alunoDb);
            _banco.SaveChanges();

            return alunoDb; 
        }

        public List<Aluno> BuscarTodos()
        {
            return _banco.Alunos.ToList();
        }

        public bool Deletar(int? id)
        {
            Aluno alunoDb = ObterPorId(id);
            if (alunoDb == null)
            {
                throw new System.Exception("Aluno não encontrado.");
            }

            _banco.Alunos.Remove(alunoDb);
            _banco.SaveChanges();
            return true;
        }

        public Aluno ObterAlunoPorEmailSenha(string email, string senha)
        {
            Aluno encontrou = _banco.Alunos.FirstOrDefault(x => x.Email == email && x.Senha == senha);

            if (encontrou == null)
            {
                return null;
            }

            return encontrou;
        }

        public Aluno ObterPorId(int? id)
        {
            return _banco.Alunos.FirstOrDefault(x => x.Id == id);
        }
    }
}
