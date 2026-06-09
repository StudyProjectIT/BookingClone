using Application.DTOs;
using Domain.Common;
using MediatR;

namespace Application.Features.Languages.Commands.CreateLanguage;

public record CreateLanguageCommand(string Name) : IRequest<Result<LanguageDto>>;
