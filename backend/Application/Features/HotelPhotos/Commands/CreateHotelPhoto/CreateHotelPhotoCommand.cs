using Application.DTOs;
using Domain.Common;
using MediatR;

namespace Application.Features.HotelPhotos.Commands.CreateHotelPhoto;

public record CreateHotelPhotoCommand(string Name, int Priority, long HotelId) : IRequest<Result<HotelPhotoDto>>;
