using Application.DTOs;
using Domain.Common;
using MediatR;

namespace Application.Features.Messages.Queries.GetMessagesByChatId;

public record GetMessagesByChatIdQuery(long ChatId) : IRequest<Result<IReadOnlyList<MessageDto>>>;
