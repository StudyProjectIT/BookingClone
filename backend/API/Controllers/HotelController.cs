using Core.DTOs;
using Core.Interfaces;
using Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController(IHotelService hotelService) : ControllerBase
    {
        // GET: api/Hotels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HotelDto>>> GetHotels()
        {
            var hotels = await hotelService.GetAllHotelsAsync();
            return Ok(hotels);
        }

        // POST: api/Hotels
        [HttpPost]
        public async Task<ActionResult<HotelDto>> CreateHotel(HotelDto hotelDto)
        {
            var createdHotel = await hotelService.CreateHotelAsync(hotelDto);
            return StatusCode(201, createdHotel);
        }

        // PUT api/Hotels/5
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateHotel(int id, HotelDto hotelDto)
        {
            if (id != hotelDto.Id) return BadRequest("wrong id");

            var updated = await hotelService.UpdateHotelAsync(id, hotelDto);
            if (!updated) return NotFound();

            return NoContent();
        }

        // DELETE api/Hotels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteHotel(int id)
        {
            var deleted = await hotelService.DeleteHotelAsync(id);
            if (!deleted) return NotFound();

            return NoContent();
        }
    }
}
