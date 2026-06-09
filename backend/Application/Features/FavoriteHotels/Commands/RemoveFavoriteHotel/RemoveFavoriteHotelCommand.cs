using Domain.Common;
using MediatR;

namespace Application.Features.FavoriteHotels.Commands.RemoveFavoriteHotel;

public record RemoveFavoriteHotelCommand(long CustomerId, long HotelId) : IRequest<Result<bool>>;
