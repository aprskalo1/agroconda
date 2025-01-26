using AgrocondaAPI.Data;
using AgrocondaAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace AgrocondaAPI.Repositories;

public interface IUserRepository
{
    Task<User> CreateUserAsync(User user);
    Task<User?> GetUserByIdAsync(Guid id);
    Task<User?> GetUserByRefreshTokenAsync(string refreshToken);
    Task<User?> GetUserByFirebaseUidAsync(string refreshToken);
    Task SaveChangesAsync();
}

public class UserRepository(AgrocondaDbContext dbContext) : IUserRepository
{
    public async Task<User> CreateUserAsync(User user)
    {
        await dbContext.Users.AddAsync(user);
        return user;
    }

    public async Task<User?> GetUserByIdAsync(Guid id)
    {
        return await dbContext.Users.FindAsync(id);
    }

    public async Task<User?> GetUserByRefreshTokenAsync(string refreshToken)
    {
        return await dbContext.RefreshTokens
            .Where(rt => rt.Token == refreshToken)
            .Select(rt => rt.User)
            .FirstOrDefaultAsync();
    }

    public async Task<User?> GetUserByFirebaseUidAsync(string refreshToken)
    {
        return await dbContext.Users
            .FirstOrDefaultAsync(u => u.FirebaseUid == refreshToken);
    }

    public async Task SaveChangesAsync()
    {
        await dbContext.SaveChangesAsync();
    }
}