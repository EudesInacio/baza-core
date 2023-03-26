using BazarCore.Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BazarCore.Services.Interfaces
{
    public interface IBaseService<TEntity> where TEntity : class, IEntity
    {
        Task<ResultService<IEnumerable<TEntity>>> GetAllAsync();
        Task<ResultService<TEntity>> GetByIdAsync(int id);
        Task<ResultService<TEntity>> AddAsync(TEntity entity);
        Task<ResultService<TEntity>> UpdateAsync(TEntity entity);
        Task<ResultService<TEntity>> DeleteAsync(int id);
        Task<ResultService<TEntity>> SoftDeleteAsync(int id);
    }
}
