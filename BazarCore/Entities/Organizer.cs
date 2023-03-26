using System;
using System.ComponentModel.DataAnnotations;
using BazarCore.Data;
using BazarCore.Data.Repository.Interfaces;
using BazarCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace BazarCore.Entities
{
    public class Organizer : BaseEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }
        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string ComercialName { get; set; }
        public string Logo { get; set; }
        public List<Event>? Events { get; set; }
    }
}
