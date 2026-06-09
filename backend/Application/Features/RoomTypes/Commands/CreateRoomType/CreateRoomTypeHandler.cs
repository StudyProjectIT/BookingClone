using Application.DTOs;
using Domain.Common;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Features.RoomTypes.Commands.CreateRoomType;

public class CreateRoomTypeHandler(IRepository<RoomType> repository)
    : IRequestHandler<CreateRoomTypeCommand, Result<RoomTypeDto>>
{
    public async Task<Result<RoomTypeDto>> Handle(CreateRoomTypeCommand request, CancellationToken ct)
    {
        if (string.IsNullOrWhiteSpace(request.Name))
            return Error.Validation("Room type name is required.");

        var entity = new RoomType { Name = request.Name };
        var created = await repository.AddAsync(entity, ct);
        return RoomTypeMappings.MapToDto(created);
    }
}
