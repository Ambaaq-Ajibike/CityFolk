using EventManagementSystem.Models.Entities;
using System.Linq.Expressions;

namespace EventManagementSystem.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<UserRole> GetUser(Expression<Func<UserRole, bool>> expression);
    }
}
