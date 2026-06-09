using Application.DTOs;
using Domain.Common;
using MediatR;

namespace Application.Features.RoomTypes.Queries.GetRoomTypeById;

public record GetRoomTypeByIdQuery(long Id) : IRequest<Result<RoomTypeDto>>;
