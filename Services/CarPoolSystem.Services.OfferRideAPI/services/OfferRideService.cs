using CarPoolSystem.Services.OfferRideAPI.Data;
using CarPoolSystem.Services.OfferRideAPI.Model;
using CarPoolSystem.Services.OfferRideAPI.Model.OfferDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarPoolSystem.Services.OfferRideAPI.Services;

public class OfferRideService
{
    private readonly MyContext _dbContext;
 

    public OfferRideService(MyContext dbContext)
    {
        _dbContext = dbContext;
    }

    public OfferDTO CreateRide(OfferDTO offerDTO)
    {
        // Validate input (you can add more validation as needed)
        if (offerDTO == null)
        {
            return null; // Return null to indicate invalid input
        }

       
        // Map OfferDTO to the entity (assuming you have an Offer entity)
        var Offer = new Offer
        {
           
            Name = offerDTO.Name,
            Source = offerDTO.Source,
            Destination = offerDTO.Destination,
            Car_Name=offerDTO.Car_Name,
            Seat_Available = offerDTO.Seat_Available,
            DepartureTime=offerDTO.DepartureTime,
            Phone_no = offerDTO.Phone_no
        };

        try
        {
            // Add the entity to the DbContext and save changes to the database
            _dbContext.Offer.Add(Offer);
            _dbContext.SaveChanges();

            // Map the created entity back to DTO and return it
            offerDTO.Offer_Id = Offer.Offer_Id; // Set the Offer_Id property to the generated ID
            return offerDTO;
        }
        catch (Exception ex)
        {
           
            return null;
        }
    }

    public List<OfferDTO> GetAllOfferRides()
    {
        try
        {
            var offerRides = _dbContext.Offer;
            // Map the Offer entities to OfferDTO
           
            var offerDTOs = offerRides.Select(offer => new OfferDTO
            {
                Offer_Id = offer.Offer_Id,
                Name = offer.Name,
                Source = offer.Source,
                Destination = offer.Destination,
                Car_Name = offer.Car_Name, 
                Seat_Available = offer.Seat_Available,
                DepartureTime=offer.DepartureTime,
                Phone_no = offer.Phone_no
            }).ToList();

            return offerDTOs;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public async Task<OfferDTO> GetOfferRideById(int id)
    {
        Offer offer = await _dbContext.Offer.FirstOrDefaultAsync(u => u.Offer_Id == id);

        var offerDtos = new OfferDTO
        {
            Offer_Id = id,
            Name = offer.Name,
            Source = offer.Source,
            Destination = offer.Destination,
            Car_Name = offer.Car_Name,
            Seat_Available = offer.Seat_Available,
            DepartureTime = offer.DepartureTime,
            Phone_no = offer.Phone_no

        };
        return offerDtos;
    }
}
