using Application.MediatR.Hotels.Queries.Shared;
using MediatR;

namespace Application.MediatR.Hotels.Queries.GetAll;

public class GetAllHotelsQuery : IRequest<IEnumerable<HotelVm>> { }
