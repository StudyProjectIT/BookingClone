using Domain.Common;
using MediatR;

namespace Application.Features.Messages.Commands.DeleteMessage;

public record DeleteMessageCommand(long Id) : IRequest<Result<bool>>;
