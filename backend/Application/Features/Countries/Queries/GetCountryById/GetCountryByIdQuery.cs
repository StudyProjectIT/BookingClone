using Application.DTOs;
using Domain.Common;
using MediatR;

namespace Application.Features.Countries.Queries.GetCountryById;

public record GetCountryByIdQuery(long Id) : IRequest<Result<CountryDto>>;
