using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JustInTimeCompany.Models
{
    public class Flight
    {
        public Airport From { get; set; }
        public DateTime TakeOff { get; set; }
        public Airport To { get; set; }
        public DateTime Landing { get; set; }

        public double Distance => 0;

        public Frequency Frequency { get; set; }
    }

    public enum Frequency
    {
        Everyday, Weekly, Monthly, Unique
    }
}
