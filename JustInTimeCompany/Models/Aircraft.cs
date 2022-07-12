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
        public AircraftModel Model { get; set; }

        [NotMapped]
        public int Capacity => Model.PassengerCapacity;

        [Display(Name ="Dernière révision")]
        public DateTime LastCheckUpDate { get; set; }

        public ICollection<Flight> FlightInstances { get; set; }

        [NotMapped, Display(Name ="Nombre de vols depuis la dernière révision")]
        public int NbFlightsSinceCheckup => (from FlightInstance in FlightInstances
                                                  where FlightInstance.Schedule.TakeOff > LastCheckUpDate
                                                  select FlightInstance).Count();

        [NotMapped]
        public bool NeedsCheckup => NbFlightsSinceCheckup >= 5;

        public void UpdateRevisionDate ()
        {
            LastCheckUpDate = DateTime.Now;
        }

    }
}
