using Application.DTOs;
using Domain.Common;
using MediatR;

namespace Application.Features.Cities.Queries.GetAllCities;

public record GetAllCitiesQuery(int Page, int PageSize) : IRequest<Result<PagedResult<CityDto>>>;
