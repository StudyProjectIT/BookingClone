using Application.DTOs;
using Domain.Common;
using Domain.Interfaces;
using MediatR;

namespace Application.Features.Hotels.Queries.GetAllHotels;

public class GetAllHotelsHandler(IHotelRepository hotelRepository)
    : IRequestHandler<GetAllHotelsQuery, Result<IReadOnlyList<HotelDto>>>
{
    public async Task<Result<IReadOnlyList<HotelDto>>> Handle(GetAllHotelsQuery request, CancellationToken ct)
    {
        var hotels = await hotelRepository.GetAllAsync();
        IReadOnlyList<HotelDto> dtos = hotels.Select(HotelMappings.MapToDto).ToList();
        return Result<IReadOnlyList<HotelDto>>.Success(dtos);
    }
}
