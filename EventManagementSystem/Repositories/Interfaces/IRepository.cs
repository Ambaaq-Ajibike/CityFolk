using EventManagementSystem.Models.Entities;
using System.Linq.Expressions;

namespace EventManagementSystem.Repositories.Interfaces
{
    public interface IRepository<T>
    {
        public Task<int> AddAsync(T entity);
        public Task<T> UpdateAsync(T entity);
        public Task<T> GetAsync(Expression<Func<T, bool>> expression);
        public Task<IList<T>> GetListAsync(Expression<Func<T, bool>> expression);
        public Task<bool> ExistsAsync(Expression<Func<T, bool>> expression);
    }
}
