using Domain.Common;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Features.HotelAmenities.Commands.DeleteHotelAmenity;

public class DeleteHotelAmenityHandler(IRepository<HotelAmenity> repository)
    : IRequestHandler<DeleteHotelAmenityCommand, Result<bool>>
{
    public async Task<Result<bool>> Handle(DeleteHotelAmenityCommand request, CancellationToken ct)
    {
        var entity = await repository.GetByIdAsync(request.Id, ct);
        if (entity is null)
            return Error.NotFound($"Hotel amenity with id {request.Id} not found.");

        await repository.DeleteAsync(request.Id, ct);
        return true;
    }
}
