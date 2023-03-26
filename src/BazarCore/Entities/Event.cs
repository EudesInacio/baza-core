using System;
using System.ComponentModel.DataAnnotations;
using BazarCore.Data;
using BazarCore.Models;

namespace BazarCore.Entities
{
    public class Event : BaseEntity
    {
        [Required]
        [StringLength(64, MinimumLength = 3)]
        public string Title { get; set; }
        [Required]
        [StringLength(200, MinimumLength = 3)]
        public string Image { get; set; }
        public string Banner { get; set; }
        public string Description { get; set; }
        public int OrganizerId { get; set; }
        public int CategoryId { get; set; }
        public int CityId { get; set; }
        public Organizer Organizer { get; set; }
        public Category Category { get; set; }
        public City City { get; set; }
        public string Adress { get; set; }
        public List<EventSession> EventSessions { get; set; }
        public bool IsPrivate { get; set; }
    }
}
