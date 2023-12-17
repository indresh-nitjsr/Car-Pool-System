using CarPoolSystem.Services.BookingAPI.Models.Dto;

namespace CarPoolSystem.Services.BookingAPI.Services.IService
{
    public interface IUserService
    {
        Task<List<UserDto>> GetAllUsers();
        Task<UserDto> GetUserById(int id);
    }
}
