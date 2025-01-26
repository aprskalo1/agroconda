using AgrocondaAPI.Data;
using AgrocondaAPI.Models.Entities;

namespace AgrocondaAPI.Repositories;

public interface IParcelRepository
{
    Task<Parcel> CreateParcelAsync(Parcel parcel);
    Task<Parcel?> GetParcelByIdAsync(Guid id);
    Task SaveChangesAsync();
}

internal class ParcelRepository(AgrocondaDbContext dbContext) : IParcelRepository
{
    public async Task<Parcel> CreateParcelAsync(Parcel parcel)
    {
        await dbContext.Parcels.AddAsync(parcel);
        return parcel;
    }

    public async Task<Parcel?> GetParcelByIdAsync(Guid id)
    {
        return await dbContext.Parcels.FindAsync(id);
    }

    public async Task SaveChangesAsync()
    {
        await dbContext.SaveChangesAsync();
    }
}