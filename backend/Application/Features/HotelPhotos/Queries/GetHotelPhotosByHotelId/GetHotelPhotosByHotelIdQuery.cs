using Application.DTOs;
using Domain.Common;
using MediatR;

namespace Application.Features.HotelPhotos.Queries.GetHotelPhotosByHotelId;

public record GetHotelPhotosByHotelIdQuery(long HotelId) : IRequest<Result<IReadOnlyList<HotelPhotoDto>>>;
