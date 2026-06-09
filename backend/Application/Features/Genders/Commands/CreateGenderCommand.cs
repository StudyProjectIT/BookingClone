using Application.DTOs;
using Domain.Common;
using MediatR;

namespace Application.Features.Genders.Commands;

public record CreateGenderCommand(string Name) : IRequest<Result<GenderDto>>;
