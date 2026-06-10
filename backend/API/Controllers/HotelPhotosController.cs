using API.Common;
using Application.Features.HotelPhotos.Commands.CreateHotelPhoto;
using Application.Features.HotelPhotos.Commands.DeleteHotelPhoto;
using Application.Features.HotelPhotos.Commands.UploadHotelPhoto;
using Application.Features.HotelPhotos.Queries.GetHotelPhotosByHotelId;
using Domain.Constants;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/hotel-photos")]
public class HotelPhotosController(IMediator mediator) : ControllerBase
{
    private const long MaxFileSizeBytes = 5 * 1024 * 1024;

    private static readonly HashSet<string> AllowedContentTypes =
    [
        "image/jpeg", "image/jpg", "image/png", "image/webp", "image/gif", "image/bmp"
    ];

    [HttpGet("by-hotel/{hotelId:long}")]
    public async Task<IActionResult> GetByHotelId(long hotelId, CancellationToken ct)
        => (await mediator.Send(new GetHotelPhotosByHotelIdQuery(hotelId), ct)).ToActionResult();

    [HttpPost]
    [Authorize(Roles = Roles.Admin + "," + Roles.Realtor)]
    public async Task<IActionResult> Create([FromBody] CreateHotelPhotoCommand command, CancellationToken ct)
        => (await mediator.Send(command, ct)).ToCreatedResult();

    [HttpPost("upload")]
    [Authorize(Roles = Roles.Admin + "," + Roles.Realtor)]
    [RequestSizeLimit(5 * 1024 * 1024 + 4096)]
    public async Task<IActionResult> Upload(
        IFormFile file,
        [FromForm] long hotelId,
        [FromForm] int priority,
        CancellationToken ct)
    {
        if (file is null || file.Length == 0)
            return BadRequest("File is required.");

        if (file.Length > MaxFileSizeBytes)
            return BadRequest("File size must not exceed 5 MB.");

        if (!AllowedContentTypes.Contains(file.ContentType.ToLowerInvariant()))
            return BadRequest("Only image files are allowed (jpeg, png, webp, gif, bmp).");

        var command = new UploadHotelPhotoCommand(
            file.OpenReadStream(),
            file.FileName,
            file.ContentType,
            priority,
            hotelId
        );

        return (await mediator.Send(command, ct)).ToCreatedResult();
    }

    [HttpDelete("{id:long}")]
    [Authorize(Roles = Roles.Admin + "," + Roles.Realtor)]
    public async Task<IActionResult> Delete(long id, CancellationToken ct)
        => (await mediator.Send(new DeleteHotelPhotoCommand(id), ct)).ToNoContentResult();
}
