using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JustInTimeCompany.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public JITCUser User { get; set; }
        public IEnumerable<Booking> Bookings { get; set; }

        public IEnumerable<Notification> Notifications { get; set; }
    }
}
