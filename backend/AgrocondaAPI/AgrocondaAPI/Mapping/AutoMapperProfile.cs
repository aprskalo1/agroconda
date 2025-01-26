using AgrocondaAPI.Models.DTOs.Request;
using AgrocondaAPI.Models.DTOs.Response;
using AgrocondaAPI.Models.Entities;
using AutoMapper;

namespace AgrocondaAPI.Mapping;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        //parcel
        CreateMap<ParcelRequestDto, Parcel>();
        CreateMap<Parcel, ParcelResponseDto>()
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt.ToLocalTime()));
        CreateMap<ParcelResponseDto, Parcel>()
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt.ToUniversalTime()));
        CreateMap<Parcel, ParcelRequestDto>();
        
        //user
        
    }
}