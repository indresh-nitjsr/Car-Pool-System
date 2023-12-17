using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarPoolSystem.Services.OfferRideAPI.Model
{
    public class Offer
    {
        [Key]
        public  int Offer_Id { get; set; }// Primary key 
       
        [Required]
        public required string Name { get; set; }
        public required string Source { set; get; }
        public required string Destination { get; set; }
        
        public required string Car_Name { get; set; }
        public required int Seat_Available { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public required DateTime DepartureTime { get; set; }
        public required long Phone_no { get; set; }

    }
}
