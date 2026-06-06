using Application.DTOs;
using Domain.Common;
using MediatR;

namespace Application.Features.Rooms.Queries.GetRoomById;

public record GetRoomByIdQuery(long Id) : IRequest<Result<RoomDto>>;
