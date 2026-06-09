using Application.DTOs;
using Domain.Common;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Features.FavoriteHotels.Queries.GetFavoriteHotelsByCustomerId;

public class GetFavoriteHotelsByCustomerIdHandler(IFavoriteHotelRepository repository)
    : IRequestHandler<GetFavoriteHotelsByCustomerIdQuery, Result<IReadOnlyList<FavoriteHotelDto>>>
{
    public async Task<Result<IReadOnlyList<FavoriteHotelDto>>> Handle(GetFavoriteHotelsByCustomerIdQuery request, CancellationToken ct)
    {
        var items = await repository.GetByCustomerIdAsync(request.CustomerId, ct);
        return items.Select(f => new FavoriteHotelDto { HotelId = f.HotelId, CustomerId = f.CustomerId })
                    .ToList()
                    .AsReadOnly();
    }
}
