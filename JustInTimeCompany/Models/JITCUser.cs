using Microsoft.AspNetCore.Identity;

namespace JustInTimeCompany.Models
{
    public abstract class JITCUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
