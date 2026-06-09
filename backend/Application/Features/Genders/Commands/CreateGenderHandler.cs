using Application.DTOs;
using Domain.Common;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Features.Genders.Commands;

public class CreateGenderHandler(IRepository<Gender> repository)
    : IRequestHandler<CreateGenderCommand, Result<GenderDto>>
{
    public async Task<Result<GenderDto>> Handle(CreateGenderCommand request, CancellationToken ct)
    {
        if (string.IsNullOrWhiteSpace(request.Name))
            return Error.Validation("Gender name is required.");
        var entity = new Gender { Name = request.Name };
        var created = await repository.AddAsync(entity, ct);
        return GenderMappings.MapToDto(created);
    }
}
