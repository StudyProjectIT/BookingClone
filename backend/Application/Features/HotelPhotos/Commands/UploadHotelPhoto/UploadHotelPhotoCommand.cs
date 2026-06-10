using Application.DTOs;
using Domain.Common;
using MediatR;

namespace Application.Features.HotelPhotos.Commands.UploadHotelPhoto;

public record UploadHotelPhotoCommand(
    Stream FileStream,
    string FileName,
    string ContentType,
    int Priority,
    long HotelId
) : IRequest<Result<HotelPhotoDto>>;
