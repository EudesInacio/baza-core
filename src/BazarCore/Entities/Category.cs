namespace BazarCore.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public string Icon { get; set; }
        public List<Event>? Events { get; set; }
    }
}
