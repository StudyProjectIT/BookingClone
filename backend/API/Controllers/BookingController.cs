//using Core.DTOs;
////using Core.Entities;
//using Core.Interfaces;
//using Microsoft.AspNetCore.Mvc;

//namespace API.Controllers
//{
//    [ApiController]
//    [Route("api/[controller]")]
//    public class BookingsController(IBookingService bookingService) : ControllerBase
//    {
//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<BookingDto>>> GetAllBookings()
//        {
//            var bookings = await bookingService.GetAllAsync();

//            var dtos = bookings.Select(b => new BookingDto
//            {
//                Id = b.Id,
//                HotelId = b.HotelId,
//                UserId = b.UserId,
//                CheckIn = b.CheckIn,
//                CheckOut = b.CheckOut,
//                Guests = b.Guests,
//                TotalPrice = b.TotalPrice
//            }).ToList();

//            return Ok(dtos);
//        }

//        [HttpGet("{id}")]
//        public async Task<ActionResult<BookingDto>> GetBooking(int id)
//        {
//            var booking = await bookingService.GetByIdAsync(id);
//            if (booking == null) return NotFound();

//            var dto = new BookingDto
//            {
//                Id = booking.Id,
//                HotelId = booking.HotelId,
//                UserId = booking.UserId,
//                CheckIn = booking.CheckIn,
//                CheckOut = booking.CheckOut,
//                Guests = booking.Guests,
//                TotalPrice = booking.TotalPrice
//            };

//            return Ok(dto);
//        }

//        [HttpPost]
//        public async Task<ActionResult<BookingDto>> CreateBooking(BookingDto dto)
//        {
//            try
//            {
//                var bookingEntity = new Booking
//                {
//                    HotelId = dto.HotelId,
//                    UserId = dto.UserId,
//                    CheckIn = dto.CheckIn,
//                    CheckOut = dto.CheckOut,
//                    Guests = dto.Guests
//                };

//                var createdBooking = await bookingService.AddAsync(bookingEntity);
//                dto.Id = createdBooking.Id;
//                dto.TotalPrice = createdBooking.TotalPrice;

//                return StatusCode(201, dto);
//            }
//            catch (ArgumentException ex)
//            {
//                return BadRequest(new { error = ex.Message });
//            }
//        }

//        [HttpPut("{id}")]
//        public async Task<ActionResult> UpdateBooking(int id, BookingDto dto)
//        {
//            if (id != dto.Id) return BadRequest("ids not matchin");

//            try
//            {
//                var bookingEntity = new Booking
//                {
//                    Id = dto.Id,
//                    HotelId = dto.HotelId,
//                    UserId = dto.UserId,
//                    CheckIn = dto.CheckIn,
//                    CheckOut = dto.CheckOut,
//                    Guests = dto.Guests
//                };

//                await bookingService.UpdateAsync(bookingEntity);
//                return NoContent();
//            }
//            catch (ArgumentException ex)
//            {
//                return NotFound(new { error = ex.Message });
//            }
//        }

//        [HttpDelete("{id}")]
//        public async Task<ActionResult> DeleteBooking(int id)
//        {
//            var existingBooking = await bookingService.GetByIdAsync(id);
//            if (existingBooking == null) return NotFound();

//            await bookingService.DeleteAsync(id);
//            return NoContent();
//        }
//    }
//}