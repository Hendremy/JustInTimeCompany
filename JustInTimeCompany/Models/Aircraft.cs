using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JustInTimeCompany.Models
{
    public class Aircraft
    {
        public int Id { get; set; }
        
        public AircraftModel Model { get; set; }

        public DateTime LastRevision { get; set; }

        public ICollection<FlightInstance> FlightsInstances { get; set; }

        //TODO: Sûrement à adapter au DbContext pour pas devoir charger ts les vols
        public bool NeedsCheckup => (from FlightInstance in FlightsInstances
                                    where FlightInstance.Schedule.TakeOff > LastRevision
                                    select FlightInstance).Count() >= 5;

    }
}
