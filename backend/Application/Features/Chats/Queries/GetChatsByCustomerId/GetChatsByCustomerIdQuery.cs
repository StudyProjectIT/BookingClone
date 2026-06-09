using Application.DTOs;
using Domain.Common;
using MediatR;

namespace Application.Features.Chats.Queries.GetChatsByCustomerId;

public record GetChatsByCustomerIdQuery(long CustomerId) : IRequest<Result<IReadOnlyList<ChatDto>>>;
