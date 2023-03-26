using BazarCore.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace BazarCore.Entities
{
    public class User : BaseEntity
    {
        [Required]
        [StringLength(16, MinimumLength = 3)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(16, MinimumLength = 3)]
        public string LastName { get; set; }
        [Required]
        [StringLength(64, MinimumLength = 6)]

        public string Username { get; set; }
        [Required]
        [StringLength(128, MinimumLength = 6)]
        [Column(Order = 4)]

        public string Email { get; set; }
        [Required]
        [StringLength(128, MinimumLength = 6)]
        public string Password { get; set; }
        public Organizer? Organizer { get; set; }
        public bool EmailConfirmed { get; set; }
    }
}
