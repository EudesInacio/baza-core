using BazarCore.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BazarCore.Models.DTO
{
    public class UserDTO
    {
        public class RegisterUserDTO
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
            public string Email { get; set; }
            [Required]
            [StringLength(128, MinimumLength = 6)]
            public string ConfirmEmail { get; set; }
            [Required]
            [StringLength(128, MinimumLength = 6)]
            public string Password { get; set; }
            public string ConfirmPassword { get; set; }
            public bool IsOrganizer { get; set; }
            public string OrganizerComercialName { get; set; }
            public bool AgreeWithTerms { get; set; }
        }
        public class UserLoginDTO
        {
            [Required]
            [StringLength(64, MinimumLength = 6)]
            public string Username { get; set; }

            [Required]
            [StringLength(128, MinimumLength = 6)]
            public string Password { get; set; }
        }

        public class UserRecoverPasswordDTO
        {
            [Required]
            [StringLength(64, MinimumLength = 6)]
            public string Username { get; set; }
        }
        public class UserResetPasswordDTO
        {
            [Required]
            [StringLength(128, MinimumLength = 6)]
            public string Token { get; set; }

            [Required]
            [StringLength(128, MinimumLength = 6)]
            public string NewPassword { get; set; }
        }

    }
}
