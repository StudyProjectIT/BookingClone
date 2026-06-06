using Application.DTOs;
using Domain.Common;
using MediatR;

namespace Application.Features.Rooms.Queries.GetRoomsByHotelId;

public record GetRoomsByHotelIdQuery(long HotelId) : IRequest<Result<List<RoomDto>>>;
