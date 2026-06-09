using Domain.Common;
using MediatR;

namespace Application.Features.HotelAmenities.Commands.DeleteHotelAmenity;

public record DeleteHotelAmenityCommand(long Id) : IRequest<Result<bool>>;
