using Domain.Common;
using MediatR;

namespace Application.Features.Languages.Commands.DeleteLanguage;

public record DeleteLanguageCommand(long Id) : IRequest<Result<bool>>;
