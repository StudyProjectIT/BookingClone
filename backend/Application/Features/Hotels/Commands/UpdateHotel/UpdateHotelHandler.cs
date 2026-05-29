using Application.DTOs;
using Domain.Common;
using Domain.Interfaces;
using MediatR;

namespace Application.Features.Hotels.Commands.UpdateHotel;

public class UpdateHotelHandler(IHotelRepository hotelRepository)
    : IRequestHandler<UpdateHotelCommand, Result<HotelDto>>
{
    public async Task<Result<HotelDto>> Handle(UpdateHotelCommand request, CancellationToken ct)
    {
        var hotel = await hotelRepository.GetByIdAsync(request.Id);
        if (hotel is null)
            return Error.NotFound($"Hotel with id {request.Id} not found.");

        if (string.IsNullOrWhiteSpace(request.Name))
            return Error.Validation("Hotel name is required.");

        hotel.Name = request.Name;
        hotel.Description = request.Description;
        hotel.AddressId = request.AddressId;
        hotel.HotelCategoryId = request.HotelCategoryId;
        hotel.RealtorId = request.RealtorId;
        hotel.ArrivalTimeUtcFrom = request.ArrivalTimeUtcFrom;
        hotel.ArrivalTimeUtcTo = request.ArrivalTimeUtcTo;
        hotel.DepartureTimeUtcFrom = request.DepartureTimeUtcFrom;
        hotel.DepartureTimeUtcTo = request.DepartureTimeUtcTo;

        await hotelRepository.UpdateAsync(hotel);
        return HotelMappings.MapToDto(hotel);
    }
}
