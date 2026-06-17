using Application.DTOs;
using Domain.Common;
using MediatR;

namespace Application.Features.Hotels.Queries.GetHotelsByRealtorId;

public record GetHotelsByRealtorIdQuery(long RealtorId) : IRequest<Result<IReadOnlyList<HotelDto>>>;
