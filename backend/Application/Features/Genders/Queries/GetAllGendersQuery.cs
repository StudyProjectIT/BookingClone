using Application.DTOs;
using Domain.Common;
using MediatR;

namespace Application.Features.Genders.Queries;

public record GetAllGendersQuery(int Page, int PageSize) : IRequest<Result<PagedResult<GenderDto>>>;
