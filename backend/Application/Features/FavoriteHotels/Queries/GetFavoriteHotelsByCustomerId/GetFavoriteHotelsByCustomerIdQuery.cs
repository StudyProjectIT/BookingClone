using Application.DTOs;
using Domain.Common;
using MediatR;

namespace Application.Features.FavoriteHotels.Queries.GetFavoriteHotelsByCustomerId;

public record GetFavoriteHotelsByCustomerIdQuery(long CustomerId) : IRequest<Result<IReadOnlyList<FavoriteHotelDto>>>;
