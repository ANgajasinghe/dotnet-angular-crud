using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Data
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        public AppDbContext AppDbContext { get; }

        public RepositoryBase(AppDbContext appDbContext)
        {
            AppDbContext = appDbContext;
        }

        public virtual async Task CreateAsync(T entity)
        {
            await AppDbContext.Set<T>().AddAsync(entity);
        }

        public void Delete(T entity)
        {
            AppDbContext.Set<T>().Remove(entity);
        }

        public virtual async Task<List<T>> FindAllAsync()
        {
            return await AppDbContext.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<List<T>> FindByConditionAsync(Expression<Func<T, bool>> expression)
        {
            return await AppDbContext.Set<T>().Where(expression).AsNoTracking().ToListAsync();
        }

        public void Update(T entity)
        {
            AppDbContext.Entry(entity).State = EntityState.Modified;
        }

        public async Task<T> FindSingleAsync(Expression<Func<T, bool>> expression)
        {
            return await AppDbContext.Set<T>().FirstOrDefaultAsync();
        }
    }
}