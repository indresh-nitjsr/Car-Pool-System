using CarPoolSystem.Services.OfferRideAPI.Model.OfferDTO;
using CarPoolSystem.Services.OfferRideAPI.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace CarPoolSystem.Services.OfferRideAPI.Controllers;


[ApiController]
[Route("api/OfferRide")]
public class OfferRideController:ControllerBase
{

    private readonly OfferRideService _service;

    public OfferRideController(OfferRideService service)
    {
        _service = service;
    }


   
    [HttpPost("Offer")]
    public IActionResult CreateRide([FromBody] OfferDTO offerDTO)
    {
        if (offerDTO == null)
        {
            return BadRequest("Invalid input: offerDTO is null.");
        }


        // You can implement the logic to create a ride here, assuming OfferRideService has a CreateRide method.
        var result = _service.CreateRide(offerDTO);

        if (result == null)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Failed to create the ride.");
        }

        // Return a 201 Created response with the created data.
        /*  return CreatedAtRoute("GetRide", new { id = result.Offer_Id }, result);*/
        return Ok("OfferRide Sucessfully ");
    }


    [HttpGet("All")]
    public IActionResult GetAllOfferRides()
    {
        // Delegate to the service layer to retrieve all offer rides
        var allOfferRides = _service.GetAllOfferRides();

        if (allOfferRides == null || allOfferRides.Count == 0)
        {
            return NotFound("No offer rides found.");
        }
     return Ok(allOfferRides); // Return all offer rides as a JSON response
    }

    /*[HttpGet("{id}")]*/
    [HttpGet("GetRideById/{id}")]
    
    public async Task<object> GetRideById(int id)
    {
        var res = await _service.GetOfferRideById(id);
        if (res != null)
        {
            return res;
        }
        return "Rider Not found";
    }

}
