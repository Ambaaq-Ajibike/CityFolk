namespace EventManagementSystem.Models.Entities
{
    public class Member : BaseEntity
    {
        public int UserId { get; set; }
        public User User { get; set; } 
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
