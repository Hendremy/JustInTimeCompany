using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JustInTimeCompany.Models
{
    public class Customer : JITCUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<Booking> Bookings { get; set; }
    }
}
