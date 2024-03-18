using Microsoft.EntityFrameworkCore;
using ShooterLink.API.Common;
using ShooterLink.API.Data;
using ShooterLink.API.Data.Entities;

namespace ShooterLink.API.Features.Auth;

public interface IAuthService
{
    Task<User?> GetUserByEmail(string email);
    Task<User?> GetUserById(Guid id);
    Task CreateUser(User user);
    Task ConfirmEmail(User user);
}

public class AuthService(DataContext dataContext) : IAuthService
{
    public async Task<User?> GetUserByEmail(string email)
    {
        return await dataContext
            .Users
            .FirstOrDefaultAsync(
                e => e.NormalizedEmail == email.ToUpper());
    }

    public async Task<User?> GetUserById(Guid id)
    {
        return await dataContext
            .Users
            .FindAsync(id);
    }

    public async Task CreateUser(User user)
    {
        var guestRole = await dataContext
            .Roles
            .FirstAsync(r => r.Name == RoleNames.Guest);

        user.Roles.Add(guestRole);

        dataContext.Add(user);
        await dataContext.SaveChangesAsync();
    }

    public async Task ConfirmEmail(User user)
    {
        user.EmailConfirmed = true;
        user.Token = null;

        await dataContext.SaveChangesAsync();
    }
}