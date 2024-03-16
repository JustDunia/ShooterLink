using FastEndpoints;
using FluentValidation;

namespace ShooterLink.API.Auth.Register;

public record RegisterRequest(
    string FirstName,
    string LastName,
    string Email,
    string Password);

public class RegisterRequestValidator : Validator<RegisterRequest>
{
    public RegisterRequestValidator()
    {
        RuleFor(r => r.FirstName)
            .NotEmpty();

        RuleFor(r => r.LastName)
            .NotEmpty();

        RuleFor(r => r.Email)
            .NotEmpty()
            .EmailAddress()
            .WithMessage("Provided email is not a valid email address");

        RuleFor(r => r.Password)
            .NotEmpty()
            .MinimumLength(8);
    }
}