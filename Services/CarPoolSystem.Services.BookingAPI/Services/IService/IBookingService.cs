using CarPoolSystem.Services.BookingAPI.Models;

namespace CarPoolSystem.Services.BookingAPI.Services.IService
{
    public interface IBookingService
    {
        Task<object> BookingRide(Booking bookRide);
    }
}
