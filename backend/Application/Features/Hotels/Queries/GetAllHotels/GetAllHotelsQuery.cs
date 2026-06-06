using Application.DTOs;
using Domain.Common;
using MediatR;

namespace Application.Features.Hotels.Queries.GetAllHotels;

public record GetAllHotelsQuery(int Page, int PageSize) : IRequest<Result<PagedResult<HotelDto>>>;
