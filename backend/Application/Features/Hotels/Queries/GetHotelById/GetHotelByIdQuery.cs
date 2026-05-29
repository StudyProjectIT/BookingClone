using Application.DTOs;
using Domain.Common;
using MediatR;

namespace Application.Features.Hotels.Queries.GetHotelById;

public record GetHotelByIdQuery(int Id) : IRequest<Result<HotelDto>>;
