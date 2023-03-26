using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BazarCore.Data.Repository.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class, IEntity
    {
        Task<PaginatedList<TReturn>> GetAllAsync<TReturn>(
            Expression<Func<TEntity, TReturn>> select,
             List<string>? include = null,
            Expression<Func<TEntity, bool>>? filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            int pageIndex = 1, int pageSize = 20);
        Task<PaginatedList<TReturn>> GetAllAsync<TReturn>(
     Expression<Func<TEntity, TReturn>> select,
      List<string>? include = null,
       IEnumerable<Expression<Func<TEntity, bool>>>? filters = null,
      Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
      int pageIndex = 1, int pageSize = 20);
        Task<List<TReturn>> GetAllAsync<TReturn>(
        Expression<Func<TEntity, TReturn>> select,
        List<string>? include = null,
        Expression<Func<TEntity, bool>>? filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null);
        Task<IList<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(int id);
        Task<TEntity> FindAsync(Expression<Func<TEntity, bool>>? filter);
        Task<TReturn> FindAsync<TReturn>(
       Expression<Func<TEntity, TReturn>> select,
       List<string>? include = null,
       Expression<Func<TEntity, bool>>? filter = null);
        Task<TEntity> AddAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task<TEntity> SoftDeleteAsync(TEntity entity);
    }
}
