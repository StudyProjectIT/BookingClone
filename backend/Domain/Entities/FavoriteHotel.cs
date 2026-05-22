using Domain.Entities.Identity;

namespace Domain.Entities;

public class FavoriteHotel {
	public long HotelId;
	public Hotel Hotel = null!;

	public long CustomerId;
	public Customer Customer = null!;
}
