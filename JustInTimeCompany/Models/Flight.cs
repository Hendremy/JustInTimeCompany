﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JustInTimeCompany.Models
{
    public class Flight
    {
        public int Id { get; set; }

        public Path Path { get; set; }

        public Pilot Pilot { get; set; }

        public Aircraft Aircraft { get; set; }

        public Schedule Schedule { get; set; }

        public FlightReport FlightReport { get; set; }
        
        public ICollection<Booking> Bookings { get; set; }

        [NotMapped]
        public int RemainingSeats => Aircraft.Capacity - Bookings.Count;

        [NotMapped]
        [Display (Name = "Arrivée")]
        public DateTime Landing => Schedule.Landing;

        [NotMapped]
        [Display (Name ="Départ")]
        public DateTime TakeOff => Schedule.TakeOff;

        [NotMapped]
        public bool HasReport => FlightReport != null;

        public Flight()
        {
            Schedule = new Schedule(DateTime.Now, DateTime.Now.AddHours(1));
        }
    }
}
