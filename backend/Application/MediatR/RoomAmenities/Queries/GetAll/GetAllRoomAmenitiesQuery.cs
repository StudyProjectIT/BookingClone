using Application.MediatR.RoomAmenities.Queries.Shared;
using MediatR;

namespace Application.MediatR.RoomAmenities.Queries.GetAll;

public class GetAllRoomAmenitiesQuery : IRequest<IEnumerable<RoomAmenityVm>> { }
