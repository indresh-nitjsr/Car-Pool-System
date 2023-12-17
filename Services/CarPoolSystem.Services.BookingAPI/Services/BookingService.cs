using CarPoolSystem.Services.BookingAPI.Data;
using CarPoolSystem.Services.BookingAPI.Models;
using CarPoolSystem.Services.BookingAPI.Services.IService;

namespace CarPoolSystem.Services.BookingAPI.Services
{
    public class BookingService : IBookingService
    {
        private readonly HttpClient client;
        private readonly AppDbContext _context;
        public BookingService(HttpClient client, AppDbContext context)
        {
            this.client = client;
            this._context = context;
        }

        public async Task<object> BookingRide(Booking bookRide)
        {
            if (bookRide == null)
            {
                return "booking failed";
            }

            _context.Bookings.Add(bookRide);
            await _context.SaveChangesAsync();
            return "Successfully booked your Ride";
        }
    }
}
