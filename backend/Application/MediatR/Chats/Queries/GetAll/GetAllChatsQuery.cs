using Application.MediatR.Chats.Queries.Shared;
using MediatR;

namespace Application.MediatR.Chats.Queries.GetAll;

public class GetAllChatsQuery : IRequest<IEnumerable<ChatVm>> { }
