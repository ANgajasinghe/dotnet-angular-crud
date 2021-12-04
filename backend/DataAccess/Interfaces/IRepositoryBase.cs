using System.Linq.Expressions;

namespace DataAccess.Data
{
    public interface IRepositoryBase<T>
    {
        Task<List<T>> FindAllAsync();

        Task<List<T>> FindByConditionAsync(Expression<Func<T, bool>> expression);

        Task<T> FindSingleAsync(Expression<Func<T, bool>> expression);

        Task CreateAsync(T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}