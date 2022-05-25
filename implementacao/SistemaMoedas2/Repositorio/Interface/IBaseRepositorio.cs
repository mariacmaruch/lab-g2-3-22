namespace SistemaMoedas2.Repositorio.Interface
{
    public interface IBaseRepositorio<TEntity> : IDisposable where TEntity : class
    {
        Task Create(TEntity entity);
        Task<TEntity> GetById(int id);
        Task<IEnumerable<TEntity>> GetAll();
        Task Update(TEntity entity);
        Task Delete(TEntity entity);
    }
}
