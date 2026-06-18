using Application.DTOs;
using Domain.Common;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Features.RoomVariants.Commands.CreateRoomVariant;

public class CreateRoomVariantHandler(IRoomVariantRepository repository)
    : IRequestHandler<CreateRoomVariantCommand, Result<RoomVariantDto>>
{
    public async Task<Result<RoomVariantDto>> Handle(CreateRoomVariantCommand request, CancellationToken ct)
    {
        if (request.Price <= 0)
            return Error.Validation("Price must be greater than zero.");

        var entity = new RoomVariant
        {
            Price = request.Price,
            DiscountPrice = request.DiscountPrice,
            RoomId = request.RoomId,
            GuestInfo = new GuestInfo { AdultCount = request.AdultCount, ChildCount = request.ChildCount },
            BedInfo = new BedInfo
            {
                SingleBedCount = request.SingleBedCount,
                DoubleBedCount = request.DoubleBedCount,
                ExtraBedCount = request.ExtraBedCount,
                SofaCount = request.SofaCount,
                KingsizeBedCount = request.KingsizeBedCount
            }
        };
        await repository.AddAsync(entity, ct);
        var created = await repository.GetByIdAsync(entity.Id, ct);
        return RoomVariantMappings.MapToDto(created!);
    }
}
