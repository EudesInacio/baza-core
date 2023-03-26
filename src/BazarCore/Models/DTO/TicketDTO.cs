using BazarCore.Entities;

namespace BazarCore.Models.DTO
{
    public class TicketDTO
    {
        public TicketDTO(Ticket ticket)
        {
            Id = ticket.Id;
            Name = ticket.Name;
            Price = ticket.Price;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
    }
}
