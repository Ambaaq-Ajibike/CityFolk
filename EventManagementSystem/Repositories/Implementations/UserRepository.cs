using EventManagementSystem.ApplicationDbContext;
using EventManagementSystem.Models.Entities;
using EventManagementSystem.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EventManagementSystem.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly EventDbContext _eventDbContext;
        public UserRepository(EventDbContext eventDbContext)
        {
            _eventDbContext = eventDbContext;
        }
        public async Task<UserRole> GetUser(Expression<Func<UserRole, bool>> expression)
        {
            return await _eventDbContext.UserRoles.Include(x => x.User).Include(x => x.Role).SingleOrDefaultAsync(expression);
        }
    }
}
