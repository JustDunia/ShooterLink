using FastEndpoints;

namespace ShooterLink.API.Features.Auth.ConfirmEmail;

public class ConfirmEmailEndpoint(IAuthService service)
    : Endpoint<ConfirmEmailRequest>
{
    public override void Configure()
    {
        Get("/api/auth/confirm-email");
        AllowAnonymous();
    }

    public override async Task HandleAsync(ConfirmEmailRequest req, CancellationToken ct)
    {
        var userId = req.UserId;
        var verificationToken = req.Token;

        try
        {
            var user = await service.GetUserById(req.UserId);

            if (user is null)
            {
                await SendNotFoundAsync(ct);
                return;
            }

            if (user.EmailConfirmed)
            {
                ThrowError("Email already confirmed");
            }

            var isTokenCorrect = string.Equals(user.Token, req.Token);
            if (!isTokenCorrect)
            {
                ThrowError("Invalid verification link");
            }

            await service.ConfirmEmail(user);
            await SendOkAsync();

            // TODO verification failed and success page
            // var html = "<div style=\"height:100vh; padding-inline:auto; font-size:4rem\">Email confirmation failed</div>";
            // await SendStringAsync(html, 400, "text/html");
        }
        catch (Exception ex)
        {
            ThrowError(ex.Message);
        }
    }
}