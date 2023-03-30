
using BazarCore.Entities;

namespace BazarCore.Models.DTO
{
    public class OrganizerDTO
    {
        public OrganizerDTO(Organizer organizer)
        {
            Name = organizer.ComercialName;
            Logo = organizer.Logo;
            CreatedAt = organizer.CreatedAt;

        }
        public string Name { get; set; }
        public string Logo { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}

