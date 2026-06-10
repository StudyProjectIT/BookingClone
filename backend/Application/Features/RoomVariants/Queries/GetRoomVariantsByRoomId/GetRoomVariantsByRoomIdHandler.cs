using Application.DTOs;
using Domain.Common;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Features.RoomVariants.Queries.GetRoomVariantsByRoomId;

public class GetRoomVariantsByRoomIdHandler(IRoomVariantRepository repository)
    : IRequestHandler<GetRoomVariantsByRoomIdQuery, Result<IReadOnlyList<RoomVariantDto>>>
{
    public async Task<Result<IReadOnlyList<RoomVariantDto>>> Handle(GetRoomVariantsByRoomIdQuery request, CancellationToken ct)
    {
        var variants = await repository.GetByRoomIdAsync(request.RoomId, ct);
        return variants.Select(RoomVariantMappings.MapToDto).ToList().AsReadOnly();
    }
}
