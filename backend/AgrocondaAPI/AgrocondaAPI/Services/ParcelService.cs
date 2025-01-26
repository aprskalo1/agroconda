using AgrocondaAPI.Exceptions;
using AgrocondaAPI.Models.DTOs.Request;
using AgrocondaAPI.Models.DTOs.Response;
using AgrocondaAPI.Models.Entities;
using AgrocondaAPI.Repositories;
using AutoMapper;

namespace AgrocondaAPI.Services;

public interface IParcelService
{
    Task<ParcelResponseDto> CreateParcel(ParcelRequestDto parcelRequestDto);
    Task<ParcelResponseDto> GetParcelById(Guid parcelId);
}

internal class ParcelService(IParcelRepository parcelRepository, IMapper mapper) : IParcelService
{
    public async Task<ParcelResponseDto> CreateParcel(ParcelRequestDto parcelRequestDto)
    {
        var parcel = mapper.Map<Parcel>(parcelRequestDto);

        await parcelRepository.CreateParcelAsync(parcel);
        await parcelRepository.SaveChangesAsync();

        return mapper.Map<ParcelResponseDto>(parcel);
    }

    public async Task<ParcelResponseDto> GetParcelById(Guid parcelId)
    {
        var parcel = await parcelRepository.GetParcelByIdAsync(parcelId);

        if (parcel is null)
        {
            throw new ParcelNotFoundException($"Parcel with id {parcelId} not found");
        }

        return mapper.Map<ParcelResponseDto>(parcel);
    }
}