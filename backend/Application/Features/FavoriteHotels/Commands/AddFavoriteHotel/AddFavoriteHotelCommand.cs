using Application.DTOs;
using Domain.Common;
using MediatR;

namespace Application.Features.FavoriteHotels.Commands.AddFavoriteHotel;

public record AddFavoriteHotelCommand(long CustomerId, long HotelId) : IRequest<Result<FavoriteHotelDto>>;
