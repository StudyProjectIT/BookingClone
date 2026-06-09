using Application.DTOs;
using Domain.Common;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Features.Breakfasts.Commands;

public class CreateBreakfastHandler(IRepository<Breakfast> repository)
    : IRequestHandler<CreateBreakfastCommand, Result<BreakfastDto>>
{
    public async Task<Result<BreakfastDto>> Handle(CreateBreakfastCommand request, CancellationToken ct)
    {
        if (string.IsNullOrWhiteSpace(request.Name))
            return Error.Validation("Breakfast name is required.");
        var entity = new Breakfast { Name = request.Name };
        var created = await repository.AddAsync(entity, ct);
        return BreakfastMappings.MapToDto(created);
    }
}
