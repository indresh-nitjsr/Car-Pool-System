using CarPoolSystem.Services.Identity.Data;
using CarPoolSystem.Services.Identity.Models.DTO;
using CarPoolSystem.Services.Identity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using BCrypt.Net;


namespace CarPoolSystem.Services.Identity.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UserController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegistrationDto registrationDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (registrationDto.Password != registrationDto.ConfirmPassword)
            {
                ModelState.AddModelError("ConfirmPassword", "The 'Password' and 'Confirm Password' fields must match.");
                return BadRequest(ModelState);
            }

            if (!IsPasswordComplex(registrationDto.Password))
            {
                ModelState.AddModelError("Password", "The password must be at least 8 characters long and contain a mix of uppercase letters, lowercase letters, numbers, and special characters.");
                return BadRequest(ModelState);
            }

            // Check if a user with the same email already exists
            var existingUser = await _context.Users.SingleOrDefaultAsync(u => u.Email == registrationDto.Email);

            if (existingUser != null)
            {
                return Conflict("A user with this email already exists.");
            }

            // Create a User entity from the RegistrationDto
            var user = new User
            {
                FirstName = registrationDto.FirstName,
                LastName = registrationDto.LastName,
                Email = registrationDto.Email,
                Location = registrationDto.Location,
                Password = registrationDto.Password // Remember to hash the password before saving it.
            };

            // Save the user to the database
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok("Registration successful");
        }
        private bool IsPasswordComplex(string password)
        {
            // Define your password complexity requirements here
            var requiredLength = 8;
            var requiresUppercase = true;
            var requiresLowercase = true;
            var requiresDigit = true;
            var requiresSpecialChar = true;

            // Check if the password meets the complexity requirements
            var hasRequiredLength = password.Length >= requiredLength;
            var hasUppercase = requiresUppercase && password.Any(char.IsUpper);
            var hasLowercase = requiresLowercase && password.Any(char.IsLower);
            var hasDigit = requiresDigit && password.Any(char.IsDigit);
            var hasSpecialChar = requiresSpecialChar && password.Any(ch => !char.IsLetterOrDigit(ch));

            return hasRequiredLength && hasUppercase && hasLowercase && hasDigit && hasSpecialChar;
        }



        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Find the user by email
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Email == loginDto.Email);

            if (user == null)
            {
                return NotFound("User not found.");
            }

            // Perform password validation (compare plain text password with stored hashed password)
            if (loginDto.Password != user.Password)
            {
                return Unauthorized("Invalid credentials.");
            }

            // TODO: Generate and return a JWT token for authentication

            return Ok("Login successful");
        }

        [HttpGet("getalluser")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _context.Users.ToListAsync();

            // Map User entities to UserDto
            var userDtos = users.Select(user => new UserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Location = user.Location,
                Email = user.Email
            }).ToList();

            return Ok(userDtos);
        }

        [HttpGet("getuserbyEmail/{email}")]
        public async Task<IActionResult> GetUserById(string email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

            // Map User entities to UserDto
            var userDtos = new UserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Location = user.Location,
                Email = user.Email
            };

            return Ok(userDtos);
        }

    }
}
