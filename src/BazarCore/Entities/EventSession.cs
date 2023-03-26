using BazarCore.Data;
using System.ComponentModel.DataAnnotations;

namespace BazarCore.Entities
{
    public class EventSession : BaseEntity
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int EventId { get; set; }
        public List<Ticket> Tickets { get; set; }
        public Event Event { get; set; }
    }
}
