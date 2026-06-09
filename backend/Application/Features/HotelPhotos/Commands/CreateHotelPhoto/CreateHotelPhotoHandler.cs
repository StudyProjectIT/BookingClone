using Application.DTOs;
using Domain.Common;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Features.HotelPhotos.Commands.CreateHotelPhoto;

public class CreateHotelPhotoHandler(IRepository<HotelPhoto> repository)
    : IRequestHandler<CreateHotelPhotoCommand, Result<HotelPhotoDto>>
{
    public async Task<Result<HotelPhotoDto>> Handle(CreateHotelPhotoCommand request, CancellationToken ct)
    {
        if (string.IsNullOrWhiteSpace(request.Name))
            return Error.Validation("Photo name is required.");

        var entity = new HotelPhoto { Name = request.Name, Priority = request.Priority, HotelId = request.HotelId };
        var created = await repository.AddAsync(entity, ct);
        return HotelPhotoMappings.MapToDto(created);
    }
}
