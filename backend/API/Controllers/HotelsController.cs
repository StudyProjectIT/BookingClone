using API.Common;
using Application.DTOs;
using Application.Interfaces;
using Domain.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HotelsController(IHotelService hotelService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetHotels(CancellationToken ct)
        => (await hotelService.GetAllHotelsAsync(ct)).ToActionResult();

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetHotel(int id, CancellationToken ct)
        => (await hotelService.GetHotelByIdAsync(id, ct)).ToActionResult();

    [HttpPost]
    [Authorize(Roles = Roles.Admin + "," + Roles.Realtor)]
    public async Task<IActionResult> CreateHotel([FromBody] HotelDto dto, CancellationToken ct)
        => (await hotelService.CreateHotelAsync(dto, ct)).ToCreatedResult();

    [HttpPut("{id:int}")]
    [Authorize(Roles = Roles.Admin + "," + Roles.Realtor)]
    public async Task<IActionResult> UpdateHotel(int id, [FromBody] HotelDto dto, CancellationToken ct)
    {
        if (id != dto.Id) return BadRequest(new { error = "ID mismatch" });
        return (await hotelService.UpdateHotelAsync(id, dto, ct)).ToNoContentResult();
    }

    [HttpDelete("{id:int}")]
    [Authorize(Roles = Roles.Admin)]
    public async Task<IActionResult> DeleteHotel(int id, CancellationToken ct)
        => (await hotelService.DeleteHotelAsync(id, ct)).ToNoContentResult();
}
