using Application.DTOs;
using Domain.Common;
using MediatR;

namespace Application.Features.HotelAmenities.Queries.GetHotelAmenityById;

public record GetHotelAmenityByIdQuery(long Id) : IRequest<Result<HotelAmenityDto>>;
