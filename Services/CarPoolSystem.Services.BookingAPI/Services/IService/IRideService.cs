using CarPoolSystem.Services.BookingAPI.Models.Dto;

namespace CarPoolSystem.Services.BookingAPI.Services.IService
{
    public interface IRideService
    {
        Task<IEnumerable<RideDto>> GetAllRide();
        Task<RideDto> GetRideById(int id);
    }
}
