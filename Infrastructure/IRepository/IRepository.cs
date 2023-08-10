
namespace Infrastructure.Repositories;

public interface IRepository<TEntity>
{
    Task<IEnumerable<TEntity>> GetAllAsync(int skip, int take);
    Task<TEntity> GetByIdAsync(int id);
    Task<int> AddAsync(TEntity entity);
    Task UpdateAsync(TEntity entity);
    Task DeleteAsync(int id);
}
