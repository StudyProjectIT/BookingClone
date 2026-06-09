using Application.DTOs;
using Domain.Entities;

namespace Application.Features.RoomVariants;

internal static class RoomVariantMappings
{
    internal static RoomVariantDto MapToDto(RoomVariant e) => new()
    {
        Id = e.Id,
        Price = e.Price,
        DiscountPrice = e.DiscountPrice,
        RoomId = e.RoomId,
        AdultCount = e.GuestInfo?.AdultCount ?? 0,
        ChildCount = e.GuestInfo?.ChildCount ?? 0,
        SingleBedCount = e.BedInfo?.SingleBedCount ?? 0,
        DoubleBedCount = e.BedInfo?.DoubleBedCount ?? 0,
        ExtraBedCount = e.BedInfo?.ExtraBedCount ?? 0,
        SofaCount = e.BedInfo?.SofaCount ?? 0,
        KingsizeBedCount = e.BedInfo?.KingsizeBedCount ?? 0
    };
}
