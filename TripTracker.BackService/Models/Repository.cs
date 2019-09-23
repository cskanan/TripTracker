using System;
using System.Collections.Generic;
using System.Linq;

namespace TripTracker.BackService.Models
{
    public class Repository
    {
        private List<Trip> myTrips = new List<Trip>
        {
            new Trip
            {
                Id = 1,
                Name ="MVP Submit",
                StartDate =  new DateTime(2019,10,8),
                EndDate =   new DateTime(2019,10,10)
            },
            new Trip
            {
                Id = 1,
                Name ="DevIntersection Orlando 2018",
                StartDate =  new DateTime(2019,10,8),
                EndDate =   new DateTime(2019,10,10)
            },
            new Trip
            {
                Id = 1,
                Name ="Build 2019",
                StartDate =  new DateTime(2019,10,8),
                EndDate =   new DateTime(2019,10,10)
            }
        };


        public List<Trip> GetTrips()
        {
            return myTrips;
        }

        public void Add(Trip trip)
        {
            myTrips.Add(trip);
        }

        public void Update(Trip trip)
        {
            myTrips.Remove(myTrips.FirstOrDefault(t => t.Id == trip.Id));
            Add(trip);
        }

        public void Remove(int id)
        {
            myTrips.Remove(myTrips.FirstOrDefault(t => t.Id == id));
        }

        public Trip GetTrip(int id)
        {
            return myTrips.FirstOrDefault(t => t.Id == id);
        }
    }
}
