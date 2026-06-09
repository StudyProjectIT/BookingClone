using Application.DTOs;
using Domain.Common;
using MediatR;

namespace Application.Features.Languages.Queries.GetLanguageById;

public record GetLanguageByIdQuery(long Id) : IRequest<Result<LanguageDto>>;
