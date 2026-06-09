using Application.DTOs;
using Domain.Common;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Features.HotelCategories.Commands.CreateHotelCategory;

public class CreateHotelCategoryHandler(IRepository<HotelCategory> repository)
    : IRequestHandler<CreateHotelCategoryCommand, Result<HotelCategoryDto>>
{
    public async Task<Result<HotelCategoryDto>> Handle(CreateHotelCategoryCommand request, CancellationToken ct)
    {
        if (string.IsNullOrWhiteSpace(request.Name))
            return Error.Validation("Hotel category name is required.");

        var entity = new HotelCategory { Name = request.Name };
        var created = await repository.AddAsync(entity, ct);
        return HotelCategoryMappings.MapToDto(created);
    }
}
