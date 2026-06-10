using Application.DTOs;
using Domain.Common;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Features.HotelPhotos.Queries.GetHotelPhotosByHotelId;

public class GetHotelPhotosByHotelIdHandler(IHotelPhotoRepository repository)
    : IRequestHandler<GetHotelPhotosByHotelIdQuery, Result<IReadOnlyList<HotelPhotoDto>>>
{
    public async Task<Result<IReadOnlyList<HotelPhotoDto>>> Handle(GetHotelPhotosByHotelIdQuery request, CancellationToken ct)
    {
        var photos = await repository.GetByHotelIdAsync(request.HotelId, ct);
        return photos.Select(HotelPhotoMappings.MapToDto).ToList().AsReadOnly();
    }
}
