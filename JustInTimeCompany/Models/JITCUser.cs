using Microsoft.AspNetCore.Identity;

namespace JustInTimeCompany.Models
{
    public class JITCUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public int? PilotId { get; set; }
        public Pilot? Pilot { get; set; }

        public int? CustomerId { get; set; }
        public Customer? Customer { get; set; }

        public string FullName => $"{FirstName} {LastName.ToUpper()}";
    }
}
