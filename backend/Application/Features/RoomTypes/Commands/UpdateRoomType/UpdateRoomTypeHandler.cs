using Application.DTOs;
using Domain.Common;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Features.RoomTypes.Commands.UpdateRoomType;

public class UpdateRoomTypeHandler(IRepository<RoomType> repository)
    : IRequestHandler<UpdateRoomTypeCommand, Result<RoomTypeDto>>
{
    public async Task<Result<RoomTypeDto>> Handle(UpdateRoomTypeCommand request, CancellationToken ct)
    {
        var entity = await repository.GetByIdAsync(request.Id, ct);
        if (entity is null)
            return Error.NotFound($"Room type with id {request.Id} not found.");

        if (string.IsNullOrWhiteSpace(request.Name))
            return Error.Validation("Room type name is required.");

        entity.Name = request.Name;
        await repository.UpdateAsync(entity, ct);
        return RoomTypeMappings.MapToDto(entity);
    }
}
