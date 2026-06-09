using Domain.Common;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Features.FavoriteHotels.Commands.RemoveFavoriteHotel;

public class RemoveFavoriteHotelHandler(IFavoriteHotelRepository repository)
    : IRequestHandler<RemoveFavoriteHotelCommand, Result<bool>>
{
    public async Task<Result<bool>> Handle(RemoveFavoriteHotelCommand request, CancellationToken ct)
    {
        var existing = await repository.GetByCustomerIdAsync(request.CustomerId, ct);
        if (!existing.Any(f => f.HotelId == request.HotelId))
            return Error.NotFound("Hotel is not in favorites.");

        await repository.RemoveAsync(request.CustomerId, request.HotelId, ct);
        return true;
    }
}
