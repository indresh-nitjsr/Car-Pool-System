using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarPoolSystem.Services.BookingAPI.Models
{
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }

        [ForeignKey("UserId")]
        public string UserId { get; set; }
        [ForeignKey("OFfer_Id")]
        public int Offer_Id { get; set; }

    }
}
