using Application.DTOs;
using Domain.Common;
using MediatR;

namespace Application.Features.Genders.Queries;

public record GetGenderByIdQuery(long Id) : IRequest<Result<GenderDto>>;
