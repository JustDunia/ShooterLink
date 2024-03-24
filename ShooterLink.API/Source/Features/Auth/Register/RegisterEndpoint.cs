using FastEndpoints;
using Microsoft.AspNetCore.Identity;
using Serilog;
using ShooterLink.API.Auth.Register;
using ShooterLink.API.Data.Entities;
using ShooterLink.API.EmailService;

namespace ShooterLink.API.Features.Auth.Register;

public class RegisterEndpoint(
    IAuthService service,
    IPasswordHasher<User> passwordHasher,
    IEmailSender emailSender)
    : Endpoint<RegisterRequest>
{
    public override void Configure()
    {
        Post("/api/auth/register");
        AllowAnonymous();
    }

    public override async Task HandleAsync(RegisterRequest req,
        CancellationToken ct)
    {
        try
        {
            var user = await service.GetUserByEmail(req.Email);

            if (user is not null)
            {
                AddError("User with this email address already exists");
            }
            else
            {
                user = new User()
                {
                    FirstName = req.FirstName,
                    LastName = req.LastName,
                    Email = req.Email,
                    NormalizedEmail = req.Email.ToUpper(),
                    Created = DateTime.Now,
                    Token = Guid.NewGuid().ToString()
                };

                var passwordHash = passwordHasher.HashPassword(user, req.Password);
                user.PasswordHash = passwordHash;

                await service.CreateUser(user);

                try
                {
                    var baseUrl = Environment.GetEnvironmentVariable("ASPNETCORE_URLS");
                    var confirmationUri = $"{baseUrl}/api/auth/confirm-email?userId={user.Id}&token={user.Token}";
                    await emailSender.SendEmailAsync(
                        user.Email,
                        "ShooterLink - email confirmation",
                        $"Welcome to ShooterLink, please click the <a href=\"{confirmationUri}\">LINK</a> to confirm your email address",
                        ct);
                }
                catch (Exception ex)
                {
                    Log.Error(ex.ToString());
                }
            }
        }
        catch (Exception ex)
        {
            AddError(ex.Message);
        }

        ThrowIfAnyErrors();
        await Task.CompletedTask;
    }
}