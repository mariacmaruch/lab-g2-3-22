using Microsoft.EntityFrameworkCore;
using SistemaMoedas2.Data;
using SistemaMoedas2.Repositorio.Interface;

namespace SistemaMoedas2.Repositorio.Implementacao
{
    public class BaseRepositorio<TEntity> : IBaseRepositorio<TEntity> where TEntity : class
    {
        protected readonly BancoContext _banco;

        public BaseRepositorio(BancoContext banco)
        {
            _banco = banco;
        }

        public async Task Create(TEntity entity)
        {
            _banco.Set<TEntity>().Add(entity);
            _banco.SaveChanges();
        }

        public async Task Delete(TEntity entity)
        {
            _banco.Remove(entity);
            _banco.SaveChanges();
        }

        public void Dispose()
        {
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            var all = await _banco.Set<TEntity>().ToListAsync();
            return all;
        }

        public async Task<TEntity> GetById(int id)
        {
            var byId = await _banco.Set<TEntity>().FindAsync(id);
            return byId;
        }

        public async Task Update(TEntity entity)
        {
            _banco.Entry(entity).State = EntityState.Modified;
            await _banco.SaveChangesAsync();
        }
    }
}
