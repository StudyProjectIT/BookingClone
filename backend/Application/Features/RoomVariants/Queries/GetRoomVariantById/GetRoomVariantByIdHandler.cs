using Application.DTOs;
using Domain.Common;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Features.RoomVariants.Queries.GetRoomVariantById;

public class GetRoomVariantByIdHandler(IRoomVariantRepository repository)
    : IRequestHandler<GetRoomVariantByIdQuery, Result<RoomVariantDto>>
{
    public async Task<Result<RoomVariantDto>> Handle(GetRoomVariantByIdQuery request, CancellationToken ct)
    {
        var entity = await repository.GetByIdAsync(request.Id, ct);
        if (entity is null)
            return Error.NotFound($"Room variant with id {request.Id} not found.");
        return RoomVariantMappings.MapToDto(entity);
    }
}
