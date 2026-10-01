using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniReservation.Api.Data;

namespace MiniReservation.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomsController : ControllerBase
    {
        private readonly AppDbContext _db;
        public RoomsController(AppDbContext db) => _db = db;

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _db.Rooms.ToListAsync());
    }
}