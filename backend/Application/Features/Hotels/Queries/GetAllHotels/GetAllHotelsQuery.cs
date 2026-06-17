using Application.DTOs;
using Domain.Common;
using MediatR;

namespace Application.Features.Hotels.Queries.GetAllHotels;

public record GetAllHotelsQuery(
    int Page,
    int PageSize,
    string? Name = null,
    long? CategoryId = null,
    string? CityName = null
) : IRequest<Result<PagedResult<HotelDto>>>;
