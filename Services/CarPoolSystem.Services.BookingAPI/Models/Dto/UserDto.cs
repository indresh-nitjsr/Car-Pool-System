using System.ComponentModel.DataAnnotations;

namespace CarPoolSystem.Services.BookingAPI.Models.Dto
{
	public class UserDto
	{
		[Key]
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Location { get; set; }
		public string Email { get; set; }
	}
}
