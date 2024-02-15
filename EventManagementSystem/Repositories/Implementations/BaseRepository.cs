using EventManagementSystem.ApplicationDbContext;
using EventManagementSystem.Models.Entities;
using EventManagementSystem.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EventManagementSystem.Repositories.Implementations
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly EventDbContext _context;
        public BaseRepository(EventDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddAsync(T entity)
        {
            _context.Set<T>().Add(entity);  
            return await  _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(Expression<Func<T, bool>> expression)
        {
            return await _context.Set<T>().AnyAsync(expression);
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> expression)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(expression);
        }

        public async Task<IList<T>> GetListAsync(Expression<Func<T, bool>> expression)
        {
            return await _context.Set<T>().Where(expression).ToListAsync();
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
