using BazarCore.Entities;
using BazarCore.Utils;
using System.ComponentModel.DataAnnotations;

namespace BazarCore.Models.DTO
{
    public class AddEventDTO
    {
        [Required]
        [StringLength(64, MinimumLength = 3)]
        public string Title { get; set; }

        [Required]
        public IFormFile Image { get; set; }

        public IFormFile Banner { get; set; }

        public string Description { get; set; }

        [Required]
        public int OrganizerId { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public int CityId { get; set; }

        public string Address { get; set; }

        public bool IsPrivate { get; set; }

        public List<EventSession> EventSessions { get; set; }
    }

    public class EventDTO
    {
        public EventDTO(Event @event)
        {
            Title = @event.Title;
            Dates = @event.EventSessions
                ?.Select(x => x.StartDate.ToString("yyyy-MM-dd"))
                .ToList();
        }
        public string Title { get; set; }
        public string FullAdress { get; set; }
        public List<string>? Dates { get; set; }
    }
    public class EventDetailsDTO : EventItemDTO
    {
        public string Banner { get; set; }
        public EventDetailsDTO(Event @event) : base(@event)
        {
            Banner = @event.Banner;
        }
    }
    public class EventItemDTO
    {
        public EventItemDTO(Event @event)
        {
            Id = @event.Id;
            Title = @event.Title;
            Image = @event.Image;
            Category = @event.Category.Name;
            Organizer = @event.Organizer?.ComercialName ?? "NA";
            OrganizerLogo = @event.Organizer?.Logo ?? "/images/default.png";
            FullAdress = @event.City?.Name + ", " + @event.Adress;
            City = @event.City?.Name;
            Description = @event.Description;
            Adress = @event.Adress;
            Tickets = @event.EventSessions?.SelectMany(x => x.Tickets)?.Select(x => new TicketDTO(x))?.ToList();
            PriceMin = Tickets != null ?
            Tickets?.OrderBy(x => x.Price).FirstOrDefault()?.Price.FormatNumberToMoney() : null;
            PriceMax = Tickets != null ?
                Tickets?.OrderByDescending(x => x.Price).FirstOrDefault()?.Price.FormatNumberToMoney() : null;


            Dates = @event.EventSessions
                ?.Select(x => x.StartDate.FormatDateToHumanReadable());
            DateStart = @event.EventSessions
                ?.OrderByDescending(x => x.StartDate)?.FirstOrDefault()?.StartDate
                  .FormatDateToHumanReadable();
            OriginalDateStart = @event.EventSessions
                ?.OrderByDescending(x => x.StartDate)?.FirstOrDefault()?.StartDate;
            DateEnd = @event.EventSessions
              ?.OrderByDescending(x => x.StartDate)?.LastOrDefault()?.EndDate
                .FormatDateToHumanReadable();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Organizer { get; set; }
        public string OrganizerEventCount { get; set; }
        public string OrganizerLogo { get; set; }
        public string Image { get; set; }
        public string City { get; set; }
        public string Adress { get; set; }
        public string FullAdress { get; set; }
        public string Category { get; set; }
        public string? PriceMin { get; set; }
        public string? PriceMax { get; set; }
        public DateTime? OriginalDateStart { get; set; }
        public string? DateStart { get; set; }
        public string? DateEnd { get; set; }
        public List<TicketDTO>? Tickets { get; set; }
        public IEnumerable<string>? Dates { get; set; }
    }
}
