using Application.DTOs;
using Domain.Common;
using MediatR;

namespace Application.Features.Messages.Commands.CreateMessage;

public record CreateMessageCommand(string Text, long ChatId, long AuthorId) : IRequest<Result<MessageDto>>;
