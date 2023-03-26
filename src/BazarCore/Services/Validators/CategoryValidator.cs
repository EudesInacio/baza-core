using BazarCore.Entities;
using FluentValidation;

namespace BazarCore.Services.Validators
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(e => e.Name).NotEmpty().WithMessage("Name is required.")
                                 .Length(3, 60).WithMessage("Name length must be between 3 and 60 characters.");
        }
    }
}