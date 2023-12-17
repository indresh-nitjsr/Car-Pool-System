using System.ComponentModel.DataAnnotations;

namespace CarPoolSystem.Services.BookingAPI.Models.Dto
{
	public class RideDto
	{
		[Key]
		public int Offer_Id { get; set; }

		public string Name { get; set; }
		public string Source { get; set; }
		public string Destination { get; set; }
		public string Car_Name { get; set; }

		public int Seat_Available { get; set; }

		// Modify DepartureTime property to return a formatted string
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
		public DateTime DepartureTime { get; set; }

		[RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must be Exactly 10 Digits .")]
		public long Phone_no { get; set; }
	}
}
