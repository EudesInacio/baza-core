using FluentValidation;
using static BazarCore.Models.DTO.UserDTO;

namespace BazarCore.Services.Validators
{
    public class UserLoginValidator : AbstractValidator<UserLoginDTO>
    {
        public UserLoginValidator()
        {
            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("Username is required.")
                .Length(3, 64).WithMessage("Username must be between 3 and 64 characters.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required.")
                .Length(6, 128).WithMessage("Password must be between 6 and 128 characters.");
        }
    }

}
