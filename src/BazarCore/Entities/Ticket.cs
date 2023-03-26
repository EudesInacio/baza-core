namespace BazarCore.Entities
{
    public class Ticket : BaseEntity
    {
        public string Name { get; set; }
        public float Price { get; set; }
        public EventSession EventSession { get; set; }
    }
}
