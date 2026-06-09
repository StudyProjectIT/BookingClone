using Application.DTOs;
using Domain.Common;
using MediatR;

namespace Application.Features.Countries.Queries.GetAllCountries;

public record GetAllCountriesQuery(int Page, int PageSize) : IRequest<Result<PagedResult<CountryDto>>>;
