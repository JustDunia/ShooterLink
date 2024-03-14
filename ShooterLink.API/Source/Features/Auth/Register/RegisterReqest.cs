using FastEndpoints;
using FluentValidation;

namespace ShooterLink.API.Auth.Register;

public record RegisterRequest(
    string Email,
    string Password);

public class RegisterRequestValidator : Validator<RegisterRequest>
{
    public RegisterRequestValidator()
    {
        RuleFor(r => r.Email)
            .NotEmpty()
            .EmailAddress()
            .WithMessage("Provided email is not a valid email address");

        RuleFor(r => r.Password)
            .NotEmpty()
            .MinimumLength(8);
    }
}