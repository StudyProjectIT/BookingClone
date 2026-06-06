using Application.MediatR.RoomTypes.Queries.Shared;
using MediatR;

namespace Application.MediatR.RoomTypes.Queries.GetAll;

public class GetAllRoomTypesQuery : IRequest<IEnumerable<RoomTypeVm>> { }
