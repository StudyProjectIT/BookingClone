using Application.DTOs;
using Domain.Common;
using MediatR;

namespace Application.Features.Citizenships.Queries;

public record GetAllCitizenshipsQuery(int Page, int PageSize) : IRequest<Result<PagedResult<CitizenshipDto>>>;
