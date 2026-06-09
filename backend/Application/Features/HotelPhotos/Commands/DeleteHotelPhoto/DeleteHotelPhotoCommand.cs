using Domain.Common;
using MediatR;

namespace Application.Features.HotelPhotos.Commands.DeleteHotelPhoto;

public record DeleteHotelPhotoCommand(long Id) : IRequest<Result<bool>>;
