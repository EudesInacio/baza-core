using BazarCore.Entities;
using FluentValidation;

namespace BazarCore.Services.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.FirstName)
                .NotEmpty().WithMessage("First name is required.")
                .Length(3, 16).WithMessage("First name must be between 3 and 16 characters long.");

            RuleFor(u => u.LastName)
                .NotEmpty().WithMessage("Last name is required.")
                .Length(3, 16).WithMessage("Last name must be between 3 and 16 characters long.");

            RuleFor(u => u.Username)
                .NotEmpty().WithMessage("Username is required.")
                .Length(6, 64).WithMessage("Username must be between 6 and 64 characters long.");

            RuleFor(u => u.Password)
                .NotEmpty().WithMessage("Password is required.")
                .Length(6, 128).WithMessage("Password must be between 6 and 128 characters long.");
        }
    }
}
