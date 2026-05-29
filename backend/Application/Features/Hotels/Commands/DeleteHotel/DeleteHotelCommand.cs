using Domain.Common;
using MediatR;

namespace Application.Features.Hotels.Commands.DeleteHotel;

public record DeleteHotelCommand(int Id) : IRequest<Result<bool>>;
