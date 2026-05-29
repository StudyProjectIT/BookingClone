using Application.DTOs;
using Domain.Common;
using Domain.Interfaces;
using MediatR;

namespace Application.Features.Hotels.Queries.GetHotelById;

public class GetHotelByIdHandler(IHotelRepository hotelRepository)
    : IRequestHandler<GetHotelByIdQuery, Result<HotelDto>>
{
    public async Task<Result<HotelDto>> Handle(GetHotelByIdQuery request, CancellationToken ct)
    {
        var hotel = await hotelRepository.GetByIdAsync(request.Id);
        if (hotel is null)
            return Error.NotFound($"Hotel with id {request.Id} not found.");

        return HotelMappings.MapToDto(hotel);
    }
}
