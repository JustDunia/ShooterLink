using FastEndpoints;
using FluentValidation;

namespace ShooterLink.API.Features.Auth.Login;

public record LoginRequest(
    string Email,
    string Password);

public class LoginRequestValidator : Validator<LoginRequest>
{
    public LoginRequestValidator()
    {
        RuleFor(r => r.Email)
            .NotEmpty()
            .EmailAddress()
            .WithMessage("Provided email is not a valid email address");

        RuleFor(r => r.Password)
            .NotEmpty();
    }
}