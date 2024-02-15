using EventManagementSystem.Models.Entities;

namespace EventManagementSystem.AuthService
{
    public interface IJWTAuthService
    {
            public string GenerateToken(User model);
    }
}
