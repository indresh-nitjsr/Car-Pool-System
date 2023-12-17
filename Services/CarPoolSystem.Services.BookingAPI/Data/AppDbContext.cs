using CarPoolSystem.Services.BookingAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CarPoolSystem.Services.BookingAPI.Data
{
    
		public class AppDbContext : DbContext
		{
			public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
			{
			}

			public DbSet<Booking>  Bookings { get; set; }
		}
	
}
