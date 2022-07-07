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
        public int Id { get; set; }
        
        [Required]
        public AircraftModel Model { get; set; }

        [NotMapped]
        public int Capacity => Model.PassengerCapacity;

        public DateTime LastRevision { get; set; }

        public ICollection<FlightInstance> FlightInstances { get; set; }

        //TODO: Sûrement à adapter au DbContext pour pas devoir charger ts les vols
        /*[NotMapped]
        public bool NeedsCheckup => (from FlightInstance in FlightInstances
                                    where FlightInstance.Schedule.TakeOff > LastRevision
                                    select FlightInstance).Count() >= 5;*/

        public void CheckUpDone ()
        {
            LastRevision = DateTime.Now;
        }

    }
}
