using Application.DTOs;
using Domain.Common;
using MediatR;

namespace Application.Features.RoomVariants.Commands.UpdateRoomVariant;

public record UpdateRoomVariantCommand(
    long Id,
    decimal Price,
    decimal? DiscountPrice,
    long RoomId,
    int AdultCount,
    int ChildCount,
    int SingleBedCount,
    int DoubleBedCount,
    int ExtraBedCount,
    int SofaCount,
    int KingsizeBedCount
) : IRequest<Result<RoomVariantDto>>;
