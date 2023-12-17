using CarPoolSystem.Web.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;


namespace CarPoolSystem.Web.Controllers
{
    public class IdentityController : Controller
    {

        private readonly IConfiguration _configuration;

        public IdentityController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

		public async Task<IActionResult> Registration()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registration(RegistrationDto registrationDto)
        {
            if (ModelState.IsValid)
            {
                string identityApiUrl = _configuration["ServiceUrls:IdentityAPI"];

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(identityApiUrl);

                    // Send the registration data to your Identity API
                    var response = await client.PostAsJsonAsync("api/user/register", registrationDto);

                    if (response.IsSuccessStatusCode)
                    {

                        return RedirectToAction("Login", "Identity");
                        // Registration was successful. You can redirect or display a success message.
                        /*TempData["success"] = "Registration Successful";
                        Response.Redirect("https://localhost:7106/Identity/Login");*/
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Registration failed. Please try again.");
                        TempData["error"] = "Registration failed";
                        
                    }
                }
            }
            return View(registrationDto);
        }


        public IActionResult Login()
        {
        
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            if (ModelState.IsValid)
            {
                string identityApiUrl = _configuration["ServiceUrls:IdentityAPI"];

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(identityApiUrl);

                    // Send the login data to your Identity API
                    var response = await client.PostAsJsonAsync("api/user/login", loginDto);

                    


                    if (response.IsSuccessStatusCode)
                    {
                        // Login was successful. You can redirect or perform other actions.
                        // For example, you can store a token in a cookie or session for authentication.


                        var userId = "";

                        var claims = new List<Claim>()
                        {
                            new Claim (ClaimTypes.Email , ClaimTypes.Name),
                             new Claim(ClaimTypes.NameIdentifier, userId)
                        };
						var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
						var principal = new ClaimsPrincipal(identity);

						await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                        return RedirectToAction("AvailableRide", "OfferRide");

						// Redirect to the home page after successful login

					}
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Login failed. Please check your credentials.");
                       TempData["error"] = "Incorrect email or Password";
                    }
                }
            }
            return View(loginDto);
        }


		[Authorize]
		[HttpPost]
		public async Task<IActionResult> Logout()
		{
			await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
			return RedirectToAction("Login","Identity");
		}



		[Authorize]
		[HttpGet]
        public async Task<IActionResult> GetUserList()
        {
            
            string identityApiUrl = _configuration["ServiceUrls:IdentityAPI"];

            List<UserDto> users = new();

            var client = new HttpClient();
            client.BaseAddress = new Uri(identityApiUrl);
            var response = await client.GetAsync("api/user/getalluser");

            if (response != null)
            {
                 users = await response.Content.ReadFromJsonAsync<List<UserDto>>();
            }
            return View(users);
        }


    }
}
