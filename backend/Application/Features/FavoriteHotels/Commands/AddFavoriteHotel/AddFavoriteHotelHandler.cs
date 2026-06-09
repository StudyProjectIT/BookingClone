using Application.DTOs;
using Domain.Common;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Features.FavoriteHotels.Commands.AddFavoriteHotel;

public class AddFavoriteHotelHandler(IFavoriteHotelRepository repository)
    : IRequestHandler<AddFavoriteHotelCommand, Result<FavoriteHotelDto>>
{
    public async Task<Result<FavoriteHotelDto>> Handle(AddFavoriteHotelCommand request, CancellationToken ct)
    {
        var existing = await repository.GetByCustomerIdAsync(request.CustomerId, ct);
        if (existing.Any(f => f.HotelId == request.HotelId))
            return Error.Conflict("Hotel is already in favorites.");

        var entity = new FavoriteHotel { CustomerId = request.CustomerId, HotelId = request.HotelId };
        await repository.AddAsync(entity, ct);
        return new FavoriteHotelDto { HotelId = request.HotelId, CustomerId = request.CustomerId };
    }
}
