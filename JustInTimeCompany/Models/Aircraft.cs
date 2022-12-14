using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JustInTimeCompany.Models
{
    public class Aircraft
    {
        [Display(Name ="#")]
        public int Id { get; set; }
        
        public int ModelId { get; set; }

        [Required]
        public AircraftModel? Model { get; set; }

        [NotMapped]
        public int? Capacity => Model.PassengerCapacity;

        [Display(Name ="Dernière révision")]
        public DateTime LastCheckUpDate { get; set; }

        public IEnumerable<Flight>? FlightInstances { get; set; }

        [NotMapped, Display(Name ="Nombre de vols depuis la dernière révision")]
        public int NbFlightsSinceCheckup => (from FlightInstance in FlightInstances
                                                  where FlightInstance.Schedule.TakeOff > LastCheckUpDate
                                                  && FlightInstance.IsPassed()
                                                  select FlightInstance).Count();

        [NotMapped]
        public bool NeedsCheckup => NbFlightsSinceCheckup >= 5;

        public void UpdateRevisionDate ()
        {
            LastCheckUpDate = DateTime.Now;
        }

        public double GetOccupationPercentage()
        {
            int flightCount = FlightInstances.Count();
            int capacity = Model.PassengerCapacity;
            double bookedSeats = 0;

            foreach(var fl in FlightInstances)
            {
                bookedSeats += fl.Bookings.Sum(b => b.SeatsTaken);
            }

            return (bookedSeats / (capacity * flightCount)) * 100;
        }

    }
}
