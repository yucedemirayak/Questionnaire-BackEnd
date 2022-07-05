using FluentValidation;
using Questionnaire.API.DTOs.User;

namespace Questionnaire.API.Validations.User
{
    public class SaveUserDTOValidator : AbstractValidator<SaveUserDTO>
    {
        public SaveUserDTOValidator()
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

        }
    }
}
