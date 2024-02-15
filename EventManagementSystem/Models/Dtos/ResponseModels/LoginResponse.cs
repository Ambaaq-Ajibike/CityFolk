using EventManagementSystem.Models.Entities;

namespace EventManagementSystem.Models.Dtos.ResponseModels
{
    public class LoginResponse
    {
        public string Token { get; set; }
        public string UserName { get; set; }
        public User User { get; set; }
    }
}
