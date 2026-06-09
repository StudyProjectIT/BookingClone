using Domain.Common;
using MediatR;

namespace Application.Features.Chats.Commands.DeleteChat;

public record DeleteChatCommand(long Id) : IRequest<Result<bool>>;
