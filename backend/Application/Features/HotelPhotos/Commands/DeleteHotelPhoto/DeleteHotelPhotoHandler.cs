using Domain.Common;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Features.HotelPhotos.Commands.DeleteHotelPhoto;

public class DeleteHotelPhotoHandler(IRepository<HotelPhoto> repository)
    : IRequestHandler<DeleteHotelPhotoCommand, Result<bool>>
{
    public async Task<Result<bool>> Handle(DeleteHotelPhotoCommand request, CancellationToken ct)
    {
        var entity = await repository.GetByIdAsync(request.Id, ct);
        if (entity is null)
            return Error.NotFound($"Hotel photo with id {request.Id} not found.");
        await repository.DeleteAsync(request.Id, ct);
        return true;
    }
}
