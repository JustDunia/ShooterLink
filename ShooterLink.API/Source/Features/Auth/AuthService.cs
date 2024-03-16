using Microsoft.EntityFrameworkCore;
using ShooterLink.API.Common;
using ShooterLink.API.Data;
using ShooterLink.API.Data.Entities;

namespace ShooterLink.API.Features.Auth;

public interface IAuthService
{
    Task<User?> GetUserByEmail(string email);
    Task CreateUser(User user);
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

    public async Task CreateUser(User user)
    {
        var guestRole = await dataContext
            .Roles
            .FirstAsync(r => r.Name == RoleNames.Guest);

        user.Roles.Add(guestRole);

        dataContext.Add(user);
        await dataContext.SaveChangesAsync();
    }
}