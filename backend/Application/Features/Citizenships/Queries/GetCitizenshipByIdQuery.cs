using Application.DTOs;
using Domain.Common;
using MediatR;

namespace Application.Features.Citizenships.Queries;

public record GetCitizenshipByIdQuery(long Id) : IRequest<Result<CitizenshipDto>>;
