using BazarCore.Entities;
using FluentValidation;

namespace BazarCore.Services.Validators
{
    public class OrganizerValidator : AbstractValidator<Organizer>
    {
        public OrganizerValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("User ID is required.");

            RuleFor(x => x.ComercialName)
                .NotEmpty().WithMessage("Commercial name is required.")
                .Length(3, 60).WithMessage("Commercial name must be between 3 and 60 characters long.");
        }
    }
}
