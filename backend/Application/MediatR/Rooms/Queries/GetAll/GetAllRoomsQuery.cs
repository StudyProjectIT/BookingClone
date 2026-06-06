using Application.MediatR.Rooms.Queries.Shared;
using MediatR;

namespace Application.MediatR.Rooms.Queries.GetAll;

public class GetAllRoomsQuery : IRequest<IEnumerable<RoomVm>> { }
