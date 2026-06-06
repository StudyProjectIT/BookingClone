using Application.MediatR.Languages.Queries.Shared;
using Application.Models.Pagination;
using MediatR;

namespace Application.MediatR.Languages.Queries.GetPage;

public class GetLanguagesPageQuery : PaginationFilterDto, IRequest<PageVm<LanguageVm>> {
	public string? Name { get; set; }
}
