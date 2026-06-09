using Application.DTOs;
using Domain.Common;
using MediatR;

namespace Application.Features.Chats.Queries.GetChatById;

public record GetChatByIdQuery(long Id) : IRequest<Result<ChatDto>>;
