using Microsoft.EntityFrameworkCore;
using MiniReservation.Api.Models;

namespace MiniReservation.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Room> Rooms => Set<Room>();
        public DbSet<Reservation> Reservations => Set<Reservation>();
    }
}