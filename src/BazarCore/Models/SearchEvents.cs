namespace BazarCore.Models
{
    public class SearchEvents
    {
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public EventTimeFilter EventTimeFilter { get; set; }
    }
    public enum EventTimeFilter
    {
        AnyTime,
        Today,
        Tomorrow,
        ThisWeek,
        NextWeek,
        NextMonth

    }
}
