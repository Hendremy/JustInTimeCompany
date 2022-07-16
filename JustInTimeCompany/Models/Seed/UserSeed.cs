using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JustInTimeCompany.Models.Seed
{
    public static class UserSeed
    {
        public static void AddDefaultRole(RoleManager<IdentityRole> rm)
        {
            IdentityRole role = rm.FindByIdAsync("1").Result;
            if (role == null)
            {
                var add = rm.CreateAsync(new IdentityRole("Manager")).Result;
                add = rm.CreateAsync(new IdentityRole("Customer")).Result;
                add = rm.CreateAsync(new IdentityRole("Pilot")).Result;
            }
        }

        public static void AddDefaultUser(UserManager<JITCUser> um)
        {
            JITCUser user = um.FindByIdAsync("1").Result;
            if (user == null)
            {
                JITCUser pilot1 = new JITCUser()
                { 
                    Email = "D.Balav@jitc.com", UserName = "D.Balav@jitc.com",
                    FirstName = "Danièle", LastName = "Balav", 
                    Pilot = new Pilot()
                };
                JITCUser pilot2 = new JITCUser() 
                { 
                    Email = "T.Sabine@jitc.com", UserName = "T.Sabine@jitc.com",
                    FirstName = "Thierry", LastName = "Sabine", 
                    Pilot = new Pilot()
                };
                JITCUser pilot3 = new JITCUser() 
                { 
                    Email = "E.Coptere@jitc.com", UserName = "E.Coptere@jitc.com", 
                    FirstName = "Eli", LastName = "Coptere", 
                    Pilot = new Pilot()
                };
                JITCUser manager = new JITCUser() 
                { 
                    Email = "M.Ney@jitc.com", UserName = "M.Ney@jitc.com",
                    FirstName = "Mo", LastName = "Ney" 
                };


                var add = um.CreateAsync(pilot1, "Test123/").Result;
                add = um.CreateAsync(pilot2, "Test123/").Result;
                add = um.CreateAsync(pilot3, "Test123/").Result;
                add = um.CreateAsync(manager, "Test123/").Result;

                if (add != null)
                {
                    var up = um.AddToRoleAsync(manager, "Manager").Result;
                    up = um.AddToRoleAsync(pilot1, "Pilot").Result;
                    up = um.AddToRoleAsync(pilot2, "Pilot").Result;
                    up = um.AddToRoleAsync(pilot3, "Pilot").Result;
                }
            }
        }

    }

}
