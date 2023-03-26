using BazarCore.Entities;
using FluentValidation;

namespace BazarCore.Services.Validators
{
    public class EventValidator : AbstractValidator<Event>
    {
        public EventValidator()
        {
            RuleFor(e => e.Title).NotEmpty().WithMessage("Title is required.")
                                 .Length(3, 60).WithMessage("Title length must be between 3 and 60 characters.");

            RuleFor(e => e.Description).NotEmpty().WithMessage("Description is required.")
                                       .Length(3, 128).WithMessage("Description length must be between 3 and 128 characters.");

        }
    }
}