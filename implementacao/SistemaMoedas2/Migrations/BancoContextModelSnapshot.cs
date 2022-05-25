﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SistemaMoedas2.Data;

#nullable disable

namespace SistemaMoedas2.Migrations
{
    [DbContext(typeof(BancoContext))]
    partial class BancoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SistemaMoedas2.Models.Aluno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ContaId")
                        .HasColumnType("int");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("InstituicaoId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rg")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ContaId")
                        .IsUnique();

                    b.HasIndex("InstituicaoId");

                    b.ToTable("Alunos");
                });

            modelBuilder.Entity("SistemaMoedas2.Models.Conta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<double>("Saldo")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Conta");
                });

            modelBuilder.Entity("SistemaMoedas2.Models.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AlunoId")
                        .HasColumnType("int");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Complemento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.Property<string>("Rua")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AlunoId")
                        .IsUnique();

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("SistemaMoedas2.Models.Instituicao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Instituicao");
                });

            modelBuilder.Entity("SistemaMoedas2.Models.Parceiro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Parceiros");
                });

            modelBuilder.Entity("SistemaMoedas2.Models.Professor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ContaId")
                        .HasColumnType("int");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Departamento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("InstituicaoId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ContaId")
                        .IsUnique();

                    b.HasIndex("InstituicaoId");

                    b.ToTable("Professores");
                });

            modelBuilder.Entity("SistemaMoedas2.Models.Aluno", b =>
                {
                    b.HasOne("SistemaMoedas2.Models.Conta", null)
                        .WithOne()
                        .HasForeignKey("SistemaMoedas2.Models.Aluno", "ContaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SistemaMoedas2.Models.Instituicao", null)
                        .WithMany()
                        .HasForeignKey("InstituicaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SistemaMoedas2.Models.Endereco", b =>
                {
                    b.HasOne("SistemaMoedas2.Models.Aluno", null)
                        .WithOne()
                        .HasForeignKey("SistemaMoedas2.Models.Endereco", "AlunoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SistemaMoedas2.Models.Professor", b =>
                {
                    b.HasOne("SistemaMoedas2.Models.Conta", null)
                        .WithOne()
                        .HasForeignKey("SistemaMoedas2.Models.Professor", "ContaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SistemaMoedas2.Models.Instituicao", null)
                        .WithMany()
                        .HasForeignKey("InstituicaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
