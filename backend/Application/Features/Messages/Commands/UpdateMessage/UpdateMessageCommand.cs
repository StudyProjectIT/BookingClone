using Application.DTOs;
using Domain.Common;
using MediatR;

namespace Application.Features.Messages.Commands.UpdateMessage;

public record UpdateMessageCommand(long Id, string Text) : IRequest<Result<MessageDto>>;
