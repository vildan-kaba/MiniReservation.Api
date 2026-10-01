using Microsoft.EntityFrameworkCore;
using MiniReservation.Api.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseInMemoryDatabase("ReservationDb"));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

// Test verisi ekle
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    if (!db.Rooms.Any())
    {
        db.Rooms.AddRange(
            new MiniReservation.Api.Models.Room { Id = 1, Name = "101", Type = "Standard", Price = 1500 },
            new MiniReservation.Api.Models.Room { Id = 2, Name = "102", Type = "Deluxe", Price = 2500 },
            new MiniReservation.Api.Models.Room { Id = 3, Name = "201", Type = "Suite", Price = 4000 }
        );
        db.SaveChanges();
    }
}

app.Run();