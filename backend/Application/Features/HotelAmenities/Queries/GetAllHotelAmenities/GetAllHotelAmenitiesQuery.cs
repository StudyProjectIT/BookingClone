using Application.DTOs;
using Domain.Common;
using MediatR;

namespace Application.Features.HotelAmenities.Queries.GetAllHotelAmenities;

public record GetAllHotelAmenitiesQuery(int Page, int PageSize) : IRequest<Result<PagedResult<HotelAmenityDto>>>;
