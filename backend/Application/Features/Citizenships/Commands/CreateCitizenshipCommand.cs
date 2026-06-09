using Application.DTOs;
using Domain.Common;
using MediatR;

namespace Application.Features.Citizenships.Commands;

public record CreateCitizenshipCommand(string Name) : IRequest<Result<CitizenshipDto>>;
