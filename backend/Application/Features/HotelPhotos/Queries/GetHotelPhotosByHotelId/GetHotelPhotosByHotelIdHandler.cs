using Application.DTOs;
using Domain.Common;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Features.HotelPhotos.Queries.GetHotelPhotosByHotelId;

public class GetHotelPhotosByHotelIdHandler(IRepository<HotelPhoto> repository)
    : IRequestHandler<GetHotelPhotosByHotelIdQuery, Result<IReadOnlyList<HotelPhotoDto>>>
{
    public async Task<Result<IReadOnlyList<HotelPhotoDto>>> Handle(GetHotelPhotosByHotelIdQuery request, CancellationToken ct)
    {
        var all = await repository.GetAllAsync(ct);
        return all.Where(p => p.HotelId == request.HotelId)
                  .OrderBy(p => p.Priority)
                  .Select(HotelPhotoMappings.MapToDto)
                  .ToList()
                  .AsReadOnly();
    }
}
