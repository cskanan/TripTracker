using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using TripTracker.BackService.Models;

namespace TripTracker.BackService.Data
{
    public class TripContext : DbContext
    {
        public DbSet<Trip> Trips { get; set; }

        public TripContext()
        {

        }

        public TripContext(DbContextOptions<TripContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Trip>().HasKey(t => t.Id);
        }

        public static void SeedData(IServiceProvider serviceProvider)
        {
            //http://thedatafarm.com/uncategorized/seeding-ef-with-json-data/

            using (
                var serviceScope = serviceProvider
                    .GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope
                    .ServiceProvider.GetService<TripContext>();

                context.Database.EnsureCreated();

                if (!context.Trips.Any())
                {
                    context.AddRange(new Trip[]{new Trip
                        {
                            Id = 1,
                            Name = "MVP Submit",
                            StartDate = new DateTime(2019, 10, 8),
                            EndDate = new DateTime(2019, 10, 10)
                        },
                        new Trip
                        {
                            Id = 2,
                            Name = "DevIntersection Orlando 2018",
                            StartDate = new DateTime(2019, 10, 8),
                            EndDate = new DateTime(2019, 10, 10)
                        },
                        new Trip
                        {
                            Id = 3,
                            Name = "Build 2019",
                            StartDate = new DateTime(2019, 10, 8),
                            EndDate = new DateTime(2019, 10, 10)
                        }});
                    context.SaveChanges();
                }
            }
        }
    }
}
