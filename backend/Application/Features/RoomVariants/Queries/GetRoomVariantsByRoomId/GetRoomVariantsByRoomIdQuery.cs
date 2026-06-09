using Application.DTOs;
using Domain.Common;
using MediatR;

namespace Application.Features.RoomVariants.Queries.GetRoomVariantsByRoomId;

public record GetRoomVariantsByRoomIdQuery(long RoomId) : IRequest<Result<IReadOnlyList<RoomVariantDto>>>;
