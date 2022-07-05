using FluentValidation;
using Questionnaire.API.DTOs.Manager;

namespace Questionnaire.API.Validations.Manager
{
    public class SaveManagerDTOValidator : AbstractValidator<SaveManagerDTO>
    {
        public SaveManagerDTOValidator()
        {
            RuleFor(a => a.FirstName)
                .NotEmpty()
                .WithMessage("Please enter your first name")
                .MaximumLength(100)
                .WithMessage("Max character size is 100.");

            RuleFor(a => a.LastName)
                .NotEmpty()
                .WithMessage("Please enter your last name")
                .MaximumLength(100)
                .WithMessage("Max character size is 100.");

            RuleFor(u => u.Email)
                .NotEmpty()
                .WithMessage("Please enter your e-mail.")
                .EmailAddress()
                .WithMessage("Please enter a valid e-mail adress.");

            RuleFor(b => b.Password)
                .NotEmpty()
                .WithMessage("Please enter your password")
                .MinimumLength(8)
                .WithMessage("Password lenght must be higher than 8 characters");

            RuleFor(x => x.CompanyId)
                .NotNull()
                .WithMessage("Please enter the company id");

        }
    }
}
