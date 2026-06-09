using Application.DTOs;
using Domain.Common;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Features.HotelCategories.Queries.GetHotelCategoryById;

public class GetHotelCategoryByIdHandler(IRepository<HotelCategory> repository)
    : IRequestHandler<GetHotelCategoryByIdQuery, Result<HotelCategoryDto>>
{
    public async Task<Result<HotelCategoryDto>> Handle(GetHotelCategoryByIdQuery request, CancellationToken ct)
    {
        var entity = await repository.GetByIdAsync(request.Id, ct);
        if (entity is null)
            return Error.NotFound($"Hotel category with id {request.Id} not found.");

        return HotelCategoryMappings.MapToDto(entity);
    }
}
