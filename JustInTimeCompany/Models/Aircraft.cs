using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JustInTimeCompany.Models
{
    public class Aircraft
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PassengerCapacity { get; set; }
        public double Speed { get; set; }
        public ICollection<Engine> Engines { get; set; }
    }
}
