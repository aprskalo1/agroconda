using AgrocondaAPI.Models.DTOs.Request;
using AgrocondaAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace AgrocondaAPI.Controllers;

[ApiController]
[Route("api/parcel")]
public class ParcelController(IParcelService parcelService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateParcel(ParcelRequestDto parcelRequestDto)
    {
        var parcel = await parcelService.CreateParcel(parcelRequestDto);

        return Created($"/api/parcel/{parcel.Id}", parcel);
    }

    [HttpGet("{parcelId:guid}")]
    public async Task<IActionResult> GetParcelById(Guid parcelId)
    {
        var parcel = await parcelService.GetParcelById(parcelId);

        return Ok(parcel);
    }
}