using Microsoft.EntityFrameworkCore;
using ShooterLink.API.Data;
using ShooterLink.API.Data.Entities;

namespace ShooterLink.API.Features.Auth;

public interface IAuthService
{
    Task<User?> GetUserByEmail(string email);
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
}