using Application.DTOs;
using Domain.Common;
using MediatR;

namespace Application.Features.Languages.Queries.GetAllLanguages;

public record GetAllLanguagesQuery(int Page, int PageSize) : IRequest<Result<PagedResult<LanguageDto>>>;
