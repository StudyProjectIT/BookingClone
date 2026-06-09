using Application.DTOs;
using Domain.Common;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Features.Breakfasts.Queries;

public class GetBreakfastByIdHandler(IRepository<Breakfast> repository)
    : IRequestHandler<GetBreakfastByIdQuery, Result<BreakfastDto>>
{
    public async Task<Result<BreakfastDto>> Handle(GetBreakfastByIdQuery request, CancellationToken ct)
    {
        var entity = await repository.GetByIdAsync(request.Id, ct);
        if (entity is null)
            return Error.NotFound($"Breakfast with id {request.Id} not found.");
        return BreakfastMappings.MapToDto(entity);
    }
}
