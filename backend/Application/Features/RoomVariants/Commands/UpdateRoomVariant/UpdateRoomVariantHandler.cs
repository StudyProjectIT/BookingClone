using Application.DTOs;
using Domain.Common;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Features.RoomVariants.Commands.UpdateRoomVariant;

public class UpdateRoomVariantHandler(IRepository<RoomVariant> repository)
    : IRequestHandler<UpdateRoomVariantCommand, Result<RoomVariantDto>>
{
    public async Task<Result<RoomVariantDto>> Handle(UpdateRoomVariantCommand request, CancellationToken ct)
    {
        var entity = await repository.GetByIdAsync(request.Id, ct);
        if (entity is null)
            return Error.NotFound($"Room variant with id {request.Id} not found.");

        if (request.Price <= 0)
            return Error.Validation("Price must be greater than zero.");

        entity.Price = request.Price;
        entity.DiscountPrice = request.DiscountPrice;
        entity.RoomId = request.RoomId;

        if (entity.GuestInfo is not null)
        {
            entity.GuestInfo.AdultCount = request.AdultCount;
            entity.GuestInfo.ChildCount = request.ChildCount;
        }
        if (entity.BedInfo is not null)
        {
            entity.BedInfo.SingleBedCount = request.SingleBedCount;
            entity.BedInfo.DoubleBedCount = request.DoubleBedCount;
            entity.BedInfo.ExtraBedCount = request.ExtraBedCount;
            entity.BedInfo.SofaCount = request.SofaCount;
            entity.BedInfo.KingsizeBedCount = request.KingsizeBedCount;
        }

        await repository.UpdateAsync(entity, ct);
        return RoomVariantMappings.MapToDto(entity);
    }
}
