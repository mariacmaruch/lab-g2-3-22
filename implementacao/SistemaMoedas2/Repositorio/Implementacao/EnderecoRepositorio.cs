using Microsoft.EntityFrameworkCore;
using SistemaMoedas2.Data;
using SistemaMoedas2.Models;
using SistemaMoedas2.Repositorio.Interface;

namespace SistemaMoedas2.Repositorio.Implementacao
{
    public class EnderecoRepositorio : IEnderecoRepositorio
    {
        private readonly BancoContext _banco;

        public EnderecoRepositorio(BancoContext banco)
        {
            _banco = banco;
        }
        public async Task CreateEndereco(Endereco endereco)
        {
            _banco.Enderecos.Add(endereco);
            await _banco.SaveChangesAsync();
        }
        public async Task UpdateEndereco(Endereco endereco)
        {
            _banco.Entry(endereco).State = EntityState.Modified;
            await _banco.SaveChangesAsync();
        }

        public async Task DeleteEndereco(Endereco endereco)
        {
            _banco.Enderecos.Remove(endereco);
            await _banco.SaveChangesAsync();
        }
        public async Task<Endereco> GetEndereco(int id)
        {
            var endereco = await _banco.Enderecos.FindAsync(id);
            return endereco;
        }

    }
}
