using FastEndpoints;
using FluentValidation;

namespace ShooterLink.API.Features.Auth.ConfirmEmail;

public class ConfirmEmailRequest(Guid userId, string token)
{
    [QueryParam] public Guid UserId { get; init; } = userId;
    [QueryParam] public string Token { get; init; } = token;
}

public class ConfirmEmailRequestValidator : Validator<ConfirmEmailRequest>
{
    public ConfirmEmailRequestValidator()
    {
        RuleFor(r => r.UserId)
            .NotEmpty();

        RuleFor(r => r.Token)
            .NotEmpty();
    }
}