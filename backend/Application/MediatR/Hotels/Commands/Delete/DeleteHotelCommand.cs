using MediatR;

namespace Application.MediatR.Hotels.Commands.Delete;

public class DeleteHotelCommand : IRequest {
	public long Id { get; set; }
}
