using System.Linq.Expressions;

namespace DataAccess.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(long id);

        Task<T?> GetByIdAsync(int id);

        Task<IEnumerable<T>> GetAllAsync();

        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> expression);

        Task AddAsync(T entity);

        Task AddRangeAsync(IEnumerable<T> entities);

        T Update(T entity);

        void Remove(T entity);

        void RemoveRange(IEnumerable<T> entities);
    }
}