using Application.MediatR.Languages.Queries.Shared;
using MediatR;

namespace Application.MediatR.Languages.Queries.GetAll;

public class GetAllLanguagesQuery : IRequest<IEnumerable<LanguageVm>> { }
