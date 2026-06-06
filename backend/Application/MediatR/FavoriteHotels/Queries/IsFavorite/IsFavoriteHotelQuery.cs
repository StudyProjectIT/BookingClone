using MediatR;

namespace Application.MediatR.FavoriteHotels.Queries.IsFavorite;

public class IsFavoriteHotelQuery : IRequest<bool> {
	public long HotelId { get; set; }
}
