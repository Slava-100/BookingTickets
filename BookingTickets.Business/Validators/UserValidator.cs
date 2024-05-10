using BookingTickets.Core.Models.BLL;
using FluentValidation;

namespace BookingTickets.Business.Validations;
public class UserValidator : AbstractValidator<User>
{
    public UserValidator()
    {
        RuleFor(user => user.Email)
            .NotEmpty().WithMessage("Email cannot be empty.")
            .EmailAddress().WithMessage("Invalid email format.")
            .Must(BeValidEmailDomain).WithMessage("Email domain must be .com or .ru.");
    }

    private bool BeValidEmailDomain(string email)
    {
        string[] validDomains = { ".com", ".ru" };
        string domain = email.Substring(email.LastIndexOf('@') + 1);

        return validDomains.Any(d => domain.EndsWith(d));
    }

}
