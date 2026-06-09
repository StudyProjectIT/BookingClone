using Application.DTOs;
using Domain.Common;
using MediatR;

namespace Application.Features.Genders.Commands;

public record UpdateGenderCommand(long Id, string Name) : IRequest<Result<GenderDto>>;
