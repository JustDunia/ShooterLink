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
        var message = "";
        int status;

        try
        {
            var user = await service.GetUserById(req.UserId);

            if (user is null)
            {
                throw new Exception("User not found");
            }

            if (user.EmailConfirmed)
            {
                throw new Exception("Email already confirmed");
            }

            var isTokenCorrect = string.Equals(user.Token, req.Token);
            if (!isTokenCorrect)
            {
                throw new Exception("Invalid verification link");
            }

            await service.ConfirmEmail(user);
            message = "Email confirmed";
            status = 200;
        }
        catch (Exception ex)
        {
            message = ex.Message;
            status = 400;
        }

        try
        {
            var htmlTemplate = await File.ReadAllTextAsync("./Features/Auth/ConfirmEmail/HtmlMessage.html", ct);
            var htmlMessage = htmlTemplate.Replace("{0}", message);
            await SendStringAsync(htmlMessage, status, "text/html");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex); // TODO logging
            var html = $"<div style=\"font-size:3rem\">{message}</div>";
            await SendStringAsync(html, status, "text/html");
        }
    }
}