using CarPoolSystem.Services.OfferRideAPI.Model;
using Microsoft.EntityFrameworkCore;


namespace CarPoolSystem.Services.OfferRideAPI.Data;

public class MyContext:DbContext
{

   
    public MyContext(DbContextOptions<MyContext>options):base(options)
    { 
    }
    public DbSet<Offer> Offer { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Offer>().HasData(new Offer
        {
            Offer_Id = 1,
            Name = "Roma",
            Source = "Hyderabad",
            Destination = "Hyderabad",
            Car_Name = "Honda",
            Seat_Available = 5,
            Phone_no = 9569045767,
            DepartureTime = new DateTime()
        });

        modelBuilder.Entity<Offer>().HasData(new Offer
        {
            Offer_Id = 2,
            Name = "Kaju",
            Source = "Hyderabad",
            Destination = "Hyderabad",
            Car_Name = "Alto",
            Seat_Available = 5,
            Phone_no = 9569045767,
            DepartureTime = new DateTime()
        });

        modelBuilder.Entity<Offer>().HasData(new Offer
        {
            Offer_Id = 3,
            Name = "Raju",
            Source = "Hyderabad",
            Destination = "Hyderabad",
            Car_Name = "BMW",
            Seat_Available = 5,
            Phone_no = 9569045767,
            DepartureTime = new DateTime()
        });
    }
}



