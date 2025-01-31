using AgrocondaAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace AgrocondaAPI.Data;

public class AgrocondaDbContext(DbContextOptions<AgrocondaDbContext> options) : DbContext(options)
{
    public DbSet<Parcel> Parcels { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }

    public DbSet<AssignedItem> AssignedItems { get; set; }

    public DbSet<AssignedItemCrop> AssignedItemCrops { get; set; }

    public DbSet<AssignedItemGroup> AssignedItemGroups { get; set; }

    public DbSet<Group> Groups { get; set; }

    public DbSet<Crop> Crops { get; set; }

    public DbSet<CropGroup> CropGroups { get; set; }

    public DbSet<CropAgroNote> CropAgroNotes { get; set; }

    public DbSet<CropAsset> CropAssets { get; set; }

    public DbSet<Asset> Assets { get; set; }

    public DbSet<AgroNote> AgroNotes { get; set; }

    public DbSet<AgroTask> AgroTasks { get; set; }

    public DbSet<ParcelGroup> ParcelGroups { get; set; }

    public DbSet<AssignedItemParcel> AssignedItemParcels { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AgroNote>()
            .Property(e => e.NoteType)
            .HasConversion<string>();
    }
}