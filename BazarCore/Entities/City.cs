namespace BazarCore.Entities
{
    public class City : BaseEntity
    {
        public string Name { get; set; }
        public string Image { get; set; }
        //add geolocation
        public List<Event> Events { get; set; }
    }
}
