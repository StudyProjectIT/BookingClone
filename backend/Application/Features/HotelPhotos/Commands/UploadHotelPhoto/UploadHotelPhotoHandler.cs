using Application.DTOs;
using Application.Interfaces;
using Domain.Common;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Features.HotelPhotos.Commands.UploadHotelPhoto;

public class UploadHotelPhotoHandler(IFileStorageService storage, IRepository<HotelPhoto> repository)
    : IRequestHandler<UploadHotelPhotoCommand, Result<HotelPhotoDto>>
{
    public async Task<Result<HotelPhotoDto>> Handle(UploadHotelPhotoCommand request, CancellationToken ct)
    {
        var url = await storage.SaveAsync(request.FileStream, request.FileName, request.ContentType, ct);

        var entity = new HotelPhoto
        {
            Name = url,
            Priority = request.Priority,
            HotelId = request.HotelId
        };

        var created = await repository.AddAsync(entity, ct);
        return HotelPhotoMappings.MapToDto(created);
    }
}
