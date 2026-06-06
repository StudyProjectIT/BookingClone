using Application.MediatR.BankCards.Queries.Shared;
using MediatR;

namespace Application.MediatR.BankCards.Queries.GetAll;

public class GetAllBankCardsQuery : IRequest<IEnumerable<BankCardVm>> { }
