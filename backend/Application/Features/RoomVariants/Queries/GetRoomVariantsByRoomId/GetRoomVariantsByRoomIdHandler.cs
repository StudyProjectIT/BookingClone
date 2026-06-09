using Application.DTOs;
using Domain.Common;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Features.RoomVariants.Queries.GetRoomVariantsByRoomId;

public class GetRoomVariantsByRoomIdHandler(IRepository<RoomVariant> repository)
    : IRequestHandler<GetRoomVariantsByRoomIdQuery, Result<IReadOnlyList<RoomVariantDto>>>
{
    public async Task<Result<IReadOnlyList<RoomVariantDto>>> Handle(GetRoomVariantsByRoomIdQuery request, CancellationToken ct)
    {
        var all = await repository.GetAllAsync(ct);
        return all.Where(v => v.RoomId == request.RoomId)
                  .Select(RoomVariantMappings.MapToDto)
                  .ToList()
                  .AsReadOnly();
    }
}
