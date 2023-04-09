
using BazarCore.Entities;
using BazarCore.Utils;

namespace BazarCore.Models.DTO
{
    public class OrganizerDTO
    {
        public OrganizerDTO(Organizer organizer)
        {
            Name = organizer.ComercialName;
            Logo = organizer.Logo;
            CreatedAt = organizer.CreatedAt.FormatDateToHumanReadable();

        }
        public string Name { get; set; }
        public string Logo { get; set; }
        public string CreatedAt { get; set; }
    }
}

