using Application.MediatR.HotelAmenities.Queries.Shared;
using MediatR;

namespace Application.MediatR.HotelAmenities.Queries.GetAll;

public class GetAllHotelAmenitiesQuery : IRequest<IEnumerable<HotelAmenityVm>> { }
