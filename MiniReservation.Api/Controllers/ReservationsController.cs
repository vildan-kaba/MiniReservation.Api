using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniReservation.Api.Data;
using MiniReservation.Api.Models;

namespace MiniReservation.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservationsController : ControllerBase
    {
        private readonly AppDbContext _db;
        public ReservationsController(AppDbContext db) => _db = db;

        [HttpGet]
        public async Task<IActionResult> GetAll()
            => Ok(await _db.Reservations.Include(r => r.Room).ToListAsync());

        [HttpPost]
        public async Task<IActionResult> Create(Reservation reservation)
        {
            bool isOverlap = await _db.Reservations.AnyAsync(r =>
                r.RoomId == reservation.RoomId &&
                r.StartDate < reservation.EndDate &&
                r.EndDate > reservation.StartDate);

            if (isOverlap)
                return BadRequest("Bu oda bu tarihlerde zaten dolu!");

            _db.Reservations.Add(reservation);
            await _db.SaveChangesAsync();
            return Ok(reservation);
        }
    }
}