using Domain.Common;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Features.HotelCategories.Commands.DeleteHotelCategory;

public class DeleteHotelCategoryHandler(IRepository<HotelCategory> repository)
    : IRequestHandler<DeleteHotelCategoryCommand, Result<bool>>
{
    public async Task<Result<bool>> Handle(DeleteHotelCategoryCommand request, CancellationToken ct)
    {
        var entity = await repository.GetByIdAsync(request.Id, ct);
        if (entity is null)
            return Error.NotFound($"Hotel category with id {request.Id} not found.");

        await repository.DeleteAsync(request.Id, ct);
        return true;
    }
}
