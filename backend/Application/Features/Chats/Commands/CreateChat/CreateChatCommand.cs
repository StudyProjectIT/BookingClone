using Application.DTOs;
using Domain.Common;
using MediatR;

namespace Application.Features.Chats.Commands.CreateChat;

public record CreateChatCommand(long CustomerId, long RealtorId) : IRequest<Result<ChatDto>>;
