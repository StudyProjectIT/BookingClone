using Application.DTOs;
using Domain.Entities;

namespace Application.Features.Addresses;

internal static class AddressMappings
{
    internal static AddressDto MapToDto(Address a) => new()
    {
        Id = a.Id,
        Street = a.Street,
        HouseNumber = a.HouseNumber,
        Floor = a.Floor,
        ApartmentNumber = a.ApartmentNumber,
        CityId = a.CityId,
        CityName = a.City?.Name ?? string.Empty
    };
}
