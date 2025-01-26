using AgrocondaAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace AgrocondaAPI.Data;

public class AgrocondaDbContext(DbContextOptions<AgrocondaDbContext> options) : DbContext(options)
{
    public DbSet<Parcel> Parcels { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }
}