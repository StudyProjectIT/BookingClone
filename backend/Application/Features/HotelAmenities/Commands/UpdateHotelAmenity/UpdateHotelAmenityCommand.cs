using Application.DTOs;
using Domain.Common;
using MediatR;

namespace Application.Features.HotelAmenities.Commands.UpdateHotelAmenity;

public record UpdateHotelAmenityCommand(long Id, string Name, string Image) : IRequest<Result<HotelAmenityDto>>;
