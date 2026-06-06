using Application.MediatR.Breakfasts.Queries.Shared;
using MediatR;

namespace Application.MediatR.Breakfasts.Queries.GetAll;

public class GetAllBreakfastsQuery : IRequest<IEnumerable<BreakfastVm>> { }
