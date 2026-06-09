using Application.DTOs;
using Domain.Common;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Features.RoomTypes.Queries.GetRoomTypeById;

public class GetRoomTypeByIdHandler(IRepository<RoomType> repository)
    : IRequestHandler<GetRoomTypeByIdQuery, Result<RoomTypeDto>>
{
    public async Task<Result<RoomTypeDto>> Handle(GetRoomTypeByIdQuery request, CancellationToken ct)
    {
        var entity = await repository.GetByIdAsync(request.Id, ct);
        if (entity is null)
            return Error.NotFound($"Room type with id {request.Id} not found.");

        return RoomTypeMappings.MapToDto(entity);
    }
}
