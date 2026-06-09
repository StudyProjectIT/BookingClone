using Application.DTOs;
using Domain.Common;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Features.HotelCategories.Commands.UpdateHotelCategory;

public class UpdateHotelCategoryHandler(IRepository<HotelCategory> repository)
    : IRequestHandler<UpdateHotelCategoryCommand, Result<HotelCategoryDto>>
{
    public async Task<Result<HotelCategoryDto>> Handle(UpdateHotelCategoryCommand request, CancellationToken ct)
    {
        var entity = await repository.GetByIdAsync(request.Id, ct);
        if (entity is null)
            return Error.NotFound($"Hotel category with id {request.Id} not found.");

        if (string.IsNullOrWhiteSpace(request.Name))
            return Error.Validation("Hotel category name is required.");

        entity.Name = request.Name;
        await repository.UpdateAsync(entity, ct);
        return HotelCategoryMappings.MapToDto(entity);
    }
}
