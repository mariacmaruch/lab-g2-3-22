using Microsoft.EntityFrameworkCore;
using SistemaMoedas2.Models;

namespace SistemaMoedas2.Data
{
    public class BancoContext : DbContext
    {
        /// <summary>
        /// Construtor
        /// </summary>
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {
        }

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Conta> Conta { get; set; }
        public DbSet<Instituicao> Instituicao { get; set; }
        public DbSet<Parceiro> Parceiros { get; set; }
        public DbSet<Professor> Professor { get; set; }
        public DbSet<Vantagem> Vantagens { get; set; }


    }
}
