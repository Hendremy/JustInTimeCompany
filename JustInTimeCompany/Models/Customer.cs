using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JustInTimeCompany.Models
{
    public class Customer
    {
        public int Id { get; set; }

        public string UserId { get; set; }
        public JITCUser User { get; set; }
        public ICollection<Booking> Bookings { get; set; }
    }
}
