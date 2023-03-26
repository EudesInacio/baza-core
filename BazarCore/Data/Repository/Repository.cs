using BazarCore.Data.Context;
using BazarCore.Data.Repository.Interfaces;
using BazarCore.Utils;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace BazarCore.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        private readonly MyContext _myContext;
        private IQueryable<TEntity> query;
        public Repository(MyContext myContext)
        {
            _myContext = myContext;
            query = _myContext.Set<TEntity>();

        }

        public async Task<IList<TEntity>> GetAllAsync()
        {
            return await _myContext.Set<TEntity>().ToListAsync();
        }
        public async Task<PaginatedList<TReturn>> GetAllAsync<TReturn>(
            Expression<Func<TEntity, TReturn>> select,
            List<string>? include = null,
            Expression<Func<TEntity, bool>>? filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            int pageIndex = 1, int pageSize = 20)
        {
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (include != null)
            {
                foreach (var item in include)
                {
                    query = query.Include(item);
                }
            }
            if (orderBy != null)
            {
                query = orderBy(query);
            }

            IQueryable<TReturn> selectedQuery;
            selectedQuery = query.Select(select);

            return await selectedQuery.GetPaginatedList(pageIndex, pageSize);
        }
        public async Task<PaginatedList<TReturn>> GetAllAsync<TReturn>(
        Expression<Func<TEntity, TReturn>> select,
         List<string>? include = null,
          IEnumerable<Expression<Func<TEntity, bool>>>? filters = null,
         Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
         int pageIndex = 1, int pageSize = 20)
        {
            if (filters != null)
            {
                foreach (var filter in filters)
                {
                    query = query.Where(filter);
                }

            }
            if (include != null)
            {
                foreach (var item in include)
                {
                    query = query.Include(item);
                }
            }
            if (orderBy != null)
            {
                query = orderBy(query);
            }

            IQueryable<TReturn> selectedQuery;
            selectedQuery = query.Select(select);

            return await selectedQuery.GetPaginatedList(pageIndex, pageSize);
        }
        public async Task<List<TReturn>> GetAllAsync<TReturn>(
        Expression<Func<TEntity, TReturn>> select,
        List<string>? include = null,
        Expression<Func<TEntity, bool>>? filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null)
        {
            IQueryable<TEntity> query = _myContext.Set<TEntity>();

            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (include != null)
            {
                foreach (var item in include)
                {
                    query.Include(item);
                }
            }
            if (orderBy != null)
            {
                query = orderBy(query);
            }

            IQueryable<TReturn> selectedQuery;
            selectedQuery = query.Select(select);

            return await selectedQuery.ToListAsync();
        }
        public async Task<TReturn> FindAsync<TReturn>(
     Expression<Func<TEntity, TReturn>> select,
     List<string>? include = null,
     Expression<Func<TEntity, bool>>? filter = null)
        {


            if (include != null)
            {
                foreach (var item in include)
                {
                    query = query.Include(item);
                }
            }
            if (filter != null)
            {
                query = query.Where(filter);
            }

            IQueryable<TReturn> selectedQuery;
            selectedQuery = query.Select(select);

            return await selectedQuery.FirstOrDefaultAsync();
        }

        public async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>>? filter)
        {
            return await _myContext.Set<TEntity>().FirstOrDefaultAsync(filter);
        }
        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _myContext.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            _myContext.Set<TEntity>().Add(entity);
            await _myContext.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            _myContext.Entry(entity).State = EntityState.Modified;
            await _myContext.SaveChangesAsync();
            return entity;
        }
        public async Task<TEntity> SoftDeleteAsync(TEntity entity)
        {
            entity.IsDeleted = true;
            _myContext.Entry(entity).State = EntityState.Modified;
            await _myContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(TEntity entity)
        {
            _myContext.Set<TEntity>().Remove(entity);
            await _myContext.SaveChangesAsync();
        }
    }
}
