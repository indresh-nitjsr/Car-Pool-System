using CarPoolSystem.Services.BookingAPI.Models.Dto;
using CarPoolSystem.Services.BookingAPI.Services.IService;
using Newtonsoft.Json;

namespace CarPoolSystem.Services.BookingAPI.Services
{
    public class RideService : IRideService
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient client;
        public RideService(HttpClient client, IConfiguration configuration)
        {
            this.client = client;
            _configuration = configuration;
        }

        public async Task<RideDto> GetRideById(int id)
        {
            string identityApiUrl = _configuration["ServiceUrls:OfferRideAPI"];
            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(identityApiUrl);

                    response = await client.GetAsync($"/api/OfferRide/GetRideById/{id}");

                    response.EnsureSuccessStatusCode(); // Throws an exception if not a success status code

                    string apiContent = await response.Content.ReadAsStringAsync();
                    RideDto ride = JsonConvert.DeserializeObject<RideDto>(apiContent);

                    return ride;
                }
            }
            catch (HttpRequestException ex)
            {
                throw new HttpRequestException($"Error: {ex.Message}");
            }
        }



        public async Task<IEnumerable<RideDto>> GetAllRide()
        {
            string identityApiUrl = _configuration["ServiceUrls:OfferRideAPI"];
            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(identityApiUrl);

                    response = await client.GetAsync("/api/OfferRide/All");

                    response.EnsureSuccessStatusCode();

                    string apiContent = await response.Content.ReadAsStringAsync();
                    List<RideDto> rides = JsonConvert.DeserializeObject<List<RideDto>>(apiContent);

                    return rides;
                }
            }
            catch (Exception)
            {
                throw new HttpRequestException($"Error: {response.StatusCode}");
            }
        }

        /*public async Task<IEnumerable<RideDto>> GetAllRide()
        {
            HttpResponseMessage response = await client.GetAsync("/api/OfferRide/All");

            if (response.IsSuccessStatusCode)
            {
                string apiContent = await response.Content.ReadAsStringAsync();
                List<RideDto> rides = JsonConvert.DeserializeObject<List<RideDto>>(apiContent);
                return rides;
            }
            else
            {
                throw new HttpRequestException($"Error: {response.StatusCode}");
            }
        }*/

        
    }
}
