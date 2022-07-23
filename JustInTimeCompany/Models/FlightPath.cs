using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JustInTimeCompany.Models
{
    public class FlightPath
    {
        public int Id { get; set; }
        public int FromId { get; set; }
        [Display (Name="Départ")]
        public Airport From { get; set; }
        public int ToId { get; set; }

        [Display (Name ="Destination")]
        public Airport To { get; set; }
        public ICollection<Flight> FlightInstances { get; set; }

        public FlightPath()
        {
        }

        public FlightPath(Airport From, Airport To)
        {
            this.From = From;
            this.To = To;
        }

        public double CalcDistance()
        {
            double longFrom = ConvertToRadians(From.Longitude);
            double latFrom = ConvertToRadians(From.Latitude);
            double longTo = ConvertToRadians(To.Longitude);
            double latTo = ConvertToRadians(To.Latitude);

            double latDiff = latTo - latFrom;
            double longDiff = longTo - longFrom;

            double a = Math.Pow(Math.Sin(latDiff / 2), 2) +
                  Math.Cos(latFrom) * Math.Cos(latTo) *
                  Math.Pow(Math.Sin(longDiff / 2), 2);

            double c = 2 * Math.Asin(Math.Sqrt(a));

            return c * 6371;
        }

        private double ConvertToRadians(double Angle)
        {
            return (Angle * Math.PI)/180;
        }


    }
}
