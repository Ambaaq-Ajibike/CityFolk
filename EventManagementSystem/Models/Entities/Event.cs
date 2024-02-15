namespace EventManagementSystem.Models.Entities
{
    public class Event : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime EventDate  { get; set; }
    }
}
