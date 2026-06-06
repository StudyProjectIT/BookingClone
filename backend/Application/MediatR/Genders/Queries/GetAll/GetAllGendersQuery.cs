using Application.MediatR.Genders.Queries.Shared;
using MediatR;

namespace Application.MediatR.Genders.Queries.GetAll;

public class GetAllGendersQuery : IRequest<IEnumerable<GenderVm>> { }
