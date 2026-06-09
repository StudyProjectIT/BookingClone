using Application.DTOs;
using Domain.Common;
using MediatR;

namespace Application.Features.Citizenships.Commands;

public record UpdateCitizenshipCommand(long Id, string Name) : IRequest<Result<CitizenshipDto>>;
