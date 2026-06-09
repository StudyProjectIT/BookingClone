using Application.DTOs;
using Domain.Common;
using MediatR;

namespace Application.Features.Cities.Queries.GetCityById;

public record GetCityByIdQuery(long Id) : IRequest<Result<CityDto>>;
