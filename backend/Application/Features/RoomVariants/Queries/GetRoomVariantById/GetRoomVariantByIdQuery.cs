using Application.DTOs;
using Domain.Common;
using MediatR;

namespace Application.Features.RoomVariants.Queries.GetRoomVariantById;

public record GetRoomVariantByIdQuery(long Id) : IRequest<Result<RoomVariantDto>>;
