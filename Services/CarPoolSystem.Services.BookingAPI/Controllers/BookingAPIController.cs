using CarPoolSystem.Services.BookingAPI.Data;
using CarPoolSystem.Services.BookingAPI.Models;
using CarPoolSystem.Services.BookingAPI.Models.Dto;
using CarPoolSystem.Services.BookingAPI.Services.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace CarPoolSystem.Services.BookingAPI.Controller
{
	[Route("api/booking")]
	[ApiController]
	public class BookingAPIController : ControllerBase
	{
		/*private readonly IConfiguration _configuration;
		private readonly HttpClient _httpClient;
        private readonly AppDbContext _context;

        public BookingAPIController(IConfiguration configuration, AppDbContext context)
		{
			_configuration = configuration;
			_httpClient = new HttpClient();
            _context = context;
        }


		

		[HttpGet("fetchUserData")]
		public async Task<IActionResult> FetchUserData()
		{
			string identityApiUrl = _configuration["ServiceUrls:IdentityAPI"];

			try
			{
				HttpResponseMessage response = await _httpClient.GetAsync($"{identityApiUrl}/api/user/getalluser");

				if (response.IsSuccessStatusCode)
				{
					string responseData = await response.Content.ReadAsStringAsync();
					// Deserialize the JSON response to your UserDto model.
					List<UserDto> userDtoList = JsonConvert.DeserializeObject<List<UserDto>>(responseData);

					// Return the user data or use it as needed.
					return Ok(userDtoList);
				}
				else
				{
					// Handle the case where the request to IdentityAPI fails.
					return BadRequest("Failed to fetch user data.");
				}
			}
			catch (HttpRequestException ex)
			{
				// Handle exceptions when making the HTTP request.
				return StatusCode(500, $"Error: {ex.Message}");
			}
		}


		[HttpGet("fetchRideData")]
		public async Task<IActionResult> FetchRideData()
		{
			string offerRideApiUrl = _configuration["ServiceUrls:OfferRideAPI"];

			try
			{
				HttpResponseMessage response = await _httpClient.GetAsync($"{offerRideApiUrl}/api/OfferRide/All");

				if (response.IsSuccessStatusCode)
				{
					string responseData = await response.Content.ReadAsStringAsync();
					// Deserialize the JSON response to your RideDto model.
					List<RideDto> rideDtoList = JsonConvert.DeserializeObject<List<RideDto>>(responseData);

					// Return the ride data or use it as needed.
					*//*return Ok(responseData);*//*
					return Ok(rideDtoList);
				}
				else
				{
					// Handle the case where the request to OfferRideAPI fails.
					return BadRequest("Failed to fetch ride data.");
				}
			}
			catch (HttpRequestException ex)
			{
				// Handle exceptions when making the HTTP request.
				return StatusCode(500, $"Error: {ex.Message}");
			}
		}

		[HttpPost("bookings")]
		public async Task<IActionResult> CreateBooking(BookingDto bookingRequest)
		{
			try
			{
				// Create a new booking record.
				var booking = new Booking
				{
					UserId = bookingRequest.UserId,
					RideId = bookingRequest.RideId,
					// You can set other booking properties like booking time, status, etc. here.
				};

				// Add the booking to the database.
				_context.Bookings.Add(booking);
				await _context.SaveChangesAsync();

				return Ok("Booking created successfully!");
			}
			catch (Exception ex)
			{
				// Handle any errors, e.g., validation errors or database errors.
				return BadRequest($"Failed to create booking: {ex.Message}");
			}
		}


*/


		private readonly IBookingService _bookingService;
		private readonly IUserService _userService;
        private readonly IRideService _rideService;

        public BookingAPIController(
            IBookingService bookingService,
            IUserService userService,
            IRideService rideService,
            IConfiguration configuration,
            IHttpClientFactory client
            )
        {
            _bookingService = bookingService;
            _userService = userService;
            _rideService = rideService;
        }

        [HttpPost("BookRide")]
        public async Task<object> Post(string userId, int rideId)
		{
            //UserDto user = await _userService.GetUserById(userId);
            //RideDto ride = await _rideService.GetRideById(rideId);
            Booking booking = new Booking
            {
                UserId = userId,
                Offer_Id = rideId,
            };
            var res = await _bookingService.BookingRide(booking);
            return res;
		}

        [HttpGet("GetUserById/{id}")]
        public async Task<object> GetUserById(int id)
        {
            var res = await _userService.GetUserById(id);
            if (res != null)
            {
                return res;
            }
            return "User Not found";
        }

        [HttpGet("GetRideById/{id}")]
        public async Task<object> GetRideById(int id)
        {
            var res = await _rideService.GetRideById(id);
            if (res != null)
            {
                return res;
            }
            return "Ride Not found";
        }
	}
}
