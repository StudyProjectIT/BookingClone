using Application.DTOs;
using Domain.Common;
using Domain.Interfaces;
using MediatR;

namespace Application.Features.Hotels.Queries.GetHotelsByRealtorId;

public class GetHotelsByRealtorIdHandler(IHotelRepository hotelRepository)
    : IRequestHandler<GetHotelsByRealtorIdQuery, Result<IReadOnlyList<HotelDto>>>
{
    public async Task<Result<IReadOnlyList<HotelDto>>> Handle(GetHotelsByRealtorIdQuery request, CancellationToken ct)
    {
        var hotels = await hotelRepository.GetByRealtorIdAsync(request.RealtorId, ct);
        return hotels.Select(HotelMappings.MapToDto).ToList().AsReadOnly();
    }
}
