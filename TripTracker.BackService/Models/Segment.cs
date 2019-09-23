using System;

namespace TripTracker.BackService.Models
{
    public class Segment
    {
        public int Id { get; set; }
        public int TripId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTimeOffset StartDateTime { get; set; }
        public DateTimeOffset EndDateTime { get; set; }
    }
}
