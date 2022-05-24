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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Endereco>()
                .HasOne<Aluno>()
                .WithOne()
                .HasForeignKey<Endereco>(p => p.AlunoId);

            modelBuilder.Entity<Instituicao>()
                .HasMany<Aluno>()
                .WithOne()
                .HasForeignKey(p => p.InstituicaoId);

            modelBuilder.Entity<Conta>()
                .HasOne<Aluno>()
                .WithOne()
                .HasForeignKey<Conta>(c => c.AlunoId);
        }


    }
}
