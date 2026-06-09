using Application.DTOs;
using Domain.Common;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Features.HotelCategories.Queries.GetAllHotelCategories;

public class GetAllHotelCategoriesHandler(IRepository<HotelCategory> repository)
    : IRequestHandler<GetAllHotelCategoriesQuery, Result<PagedResult<HotelCategoryDto>>>
{
    public async Task<Result<PagedResult<HotelCategoryDto>>> Handle(GetAllHotelCategoriesQuery request, CancellationToken ct)
    {
        var (items, totalCount) = await repository.GetPagedAsync(request.Page, request.PageSize, ct);
        return new PagedResult<HotelCategoryDto>
        {
            Items = items.Select(HotelCategoryMappings.MapToDto).ToList().AsReadOnly(),
            TotalCount = totalCount,
            Page = request.Page,
            PageSize = request.PageSize
        };
    }
}
