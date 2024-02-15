namespace EventManagementSystem.Models.Entities
{
    public class User : BaseEntity
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public List<UserRole> UserRoles { get; set; } = new();
    }
}
