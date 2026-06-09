using Application.DTOs;
using Domain.Common;
using MediatR;

namespace Application.Features.Languages.Commands.UpdateLanguage;

public record UpdateLanguageCommand(long Id, string Name) : IRequest<Result<LanguageDto>>;
