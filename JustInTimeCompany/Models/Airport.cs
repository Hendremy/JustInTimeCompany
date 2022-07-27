using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JustInTimeCompany.Models
{
    public class Airport
    {
        public int Id { get; set; }
        public string Name { get; init; }
        public string Location { get; init; }
        public double Longitude { get; init; }
        public double Latitude { get; init; }

        public IEnumerable<FlightPath> OutgoingFlights { get; init; }


        public IEnumerable<FlightPath> IncomingFlights { get; init; }
    }
}
