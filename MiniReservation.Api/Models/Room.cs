namespace MiniReservation.Api.Models
{
    public class Room
    {
       
            public int Id { get; set; }
            public string Name { get; set; } = "";
            public string Type { get; set; } = "Standard"; // Standard, Deluxe, Suite
            public decimal Price { get; set; }
        }

        public class Reservation
        {
            public int Id { get; set; }
            public int RoomId { get; set; }
            public Room? Room { get; set; }
            public string CustomerName { get; set; } = "";
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
        }
}

