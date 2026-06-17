using Application.Interfaces;
using Domain.Common;
using Domain.Constants;
using Domain.Interfaces;
using MediatR;

namespace Application.Features.Hotels.Commands.DeleteHotel;

public class DeleteHotelHandler(IHotelRepository hotelRepository, ICurrentUserService currentUser)
    : IRequestHandler<DeleteHotelCommand, Result<bool>>
{
    public async Task<Result<bool>> Handle(DeleteHotelCommand request, CancellationToken ct)
    {
        var hotel = await hotelRepository.GetByIdAsync(request.Id);
        if (hotel is null)
            return Error.NotFound($"Hotel with id {request.Id} not found.");

        if (!currentUser.IsInRole(Roles.Admin) && hotel.RealtorId != currentUser.GetUserId())
            return Error.Forbidden("You do not have access to this resource.");

        await hotelRepository.DeleteAsync(request.Id);
        return true;
    }
}
