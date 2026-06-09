using Application.DTOs;
using Domain.Common;
using MediatR;

namespace Application.Features.HotelAmenities.Commands.CreateHotelAmenity;

public record CreateHotelAmenityCommand(string Name, string Image) : IRequest<Result<HotelAmenityDto>>;
