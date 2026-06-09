using Application.DTOs;
using Domain.Common;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Features.Languages.Queries.GetAllLanguages;

public class GetAllLanguagesHandler(IRepository<Language> repository)
    : IRequestHandler<GetAllLanguagesQuery, Result<PagedResult<LanguageDto>>>
{
    public async Task<Result<PagedResult<LanguageDto>>> Handle(GetAllLanguagesQuery request, CancellationToken ct)
    {
        var (items, totalCount) = await repository.GetPagedAsync(request.Page, request.PageSize, ct);
        return new PagedResult<LanguageDto>
        {
            Items = items.Select(LanguageMappings.MapToDto).ToList().AsReadOnly(),
            TotalCount = totalCount,
            Page = request.Page,
            PageSize = request.PageSize
        };
    }
}
