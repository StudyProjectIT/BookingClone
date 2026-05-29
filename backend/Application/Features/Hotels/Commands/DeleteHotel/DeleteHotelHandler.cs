using Domain.Common;
using Domain.Interfaces;
using MediatR;

namespace Application.Features.Hotels.Commands.DeleteHotel;

public class DeleteHotelHandler(IHotelRepository hotelRepository)
    : IRequestHandler<DeleteHotelCommand, Result<bool>>
{
    public async Task<Result<bool>> Handle(DeleteHotelCommand request, CancellationToken ct)
    {
        var hotel = await hotelRepository.GetByIdAsync(request.Id);
        if (hotel is null)
            return Error.NotFound($"Hotel with id {request.Id} not found.");

        await hotelRepository.DeleteAsync(request.Id);
        return true;
    }
}
