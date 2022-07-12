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
        public double Longitude { get; init; }
        public double Latitude { get; init; }

        public ICollection<Path> OutgoingFlights { get; init; }


        public ICollection<Path> IncomingFlights { get; init; }
    }
}
