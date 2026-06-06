using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.MediatR.HotelAmenities.Commands.Create;

public class CreateHotelAmenityCommand : IRequest<long> {
	public string Name { get; set; } = null!;

	public IFormFile Image { get; set; } = null!;
}
