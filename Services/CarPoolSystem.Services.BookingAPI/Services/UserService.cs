using CarPoolSystem.Services.BookingAPI.Models.Dto;
using CarPoolSystem.Services.BookingAPI.Services.IService;
using Newtonsoft.Json;

namespace CarPoolSystem.Services.BookingAPI.Services
{
    public class UserService :IUserService
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient client;
        public UserService(HttpClient client, IConfiguration configuration)
        {
            this.client = client;
            _configuration = configuration;
        }

        public async Task<List<UserDto>> GetAllUsers()
        {
            string identityApiUrl = _configuration["ServiceUrls:IdentityAPI"];
            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(identityApiUrl);

                    response = await client.GetAsync("/api/User/getalluser");

                    response.EnsureSuccessStatusCode();

                    string apiContent = await response.Content.ReadAsStringAsync();
                    List<UserDto> users = JsonConvert.DeserializeObject<List<UserDto>>(apiContent);

                    return users;
                }
            }
            catch (Exception)
            {
                throw new HttpRequestException($"Error: {response.StatusCode}");
            }
        }

        public async Task<UserDto> GetUserById(int id)
        {
            string identityApiUrl = _configuration["ServiceUrls:IdentityAPI"];
            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(identityApiUrl);

                    response = await client.GetAsync($"/api/user/getuserbyid/{id}");

                    response.EnsureSuccessStatusCode(); // Throws an exception if not a success status code

                    string apiContent = await response.Content.ReadAsStringAsync();
                    UserDto user = JsonConvert.DeserializeObject<UserDto>(apiContent);

                    return user;
                }
            }
            catch (HttpRequestException ex)
            {
                throw new HttpRequestException($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new HttpRequestException($"Error: {response.StatusCode}");
            }

            /**************************************************************/
            /*string identityApiUrl = _configuration["ServiceUrls:IdentityAPI"];
            HttpResponseMessage response = await client.GetAsync($"/api/user/getuserbyid/{id}");

            if (response.IsSuccessStatusCode)
            {
                string apiContent = await response.Content.ReadAsStringAsync();
                UserDto user = JsonConvert.DeserializeObject<UserDto>(apiContent);
                return user;
            }
            else
            {
                throw new HttpRequestException($"Error: {response.StatusCode}");
            }*/
        }
    }
}
