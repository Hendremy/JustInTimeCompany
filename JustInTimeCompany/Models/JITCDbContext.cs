using JustInTimeCompany.Models.Seed;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JustInTimeCompany.Models
{
    public class JITCDbContext : IdentityDbContext<JITCUser>
    {
        public JITCDbContext(DbContextOptions<JITCDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            BuildBooking(modelBuilder);

            BuildFlight(modelBuilder);
            
            BuildPath(modelBuilder);

            BuildEngineInAircraft(modelBuilder);
            
            BuildUser(modelBuilder);

            BuildModificationLogs(modelBuilder);

            Seed(modelBuilder);
        }

        private void BuildBooking(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasMany(c => c.Bookings)
                .WithOne(b => b.Customer)
                .HasForeignKey(c => c.CustomerId);
        }

        private void BuildFlight(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FlightReport>().HasOne(fr => fr.Flight)
                .WithOne(fi => fi.FlightReport)
                .HasForeignKey<FlightReport>(fr => fr.FlightId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Flight>().HasOne(fl => fl.Aircraft).WithMany(fr => fr.FlightInstances);

            modelBuilder.Entity<Flight>().HasOne(fl => fl.Pilot)
                .WithMany(p => p.FlightInstances)
                .HasForeignKey(fl => fl.PilotId)
                .OnDelete(DeleteBehavior.NoAction);

        }

        private void BuildPath(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FlightPath>().HasOne(f => f.From)
                .WithMany(a => a.OutgoingFlights)
                .HasForeignKey(f => f.FromId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<FlightPath>().HasOne(f => f.To)
                .WithMany(a => a.IncomingFlights)
                .HasForeignKey(f => f.ToId)
                .OnDelete(DeleteBehavior.NoAction);
        }

        private void BuildEngineInAircraft(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EngineInAircraft>().HasKey(eia => new { eia.EngineId, eia.ModelId });
        }

        private void BuildUser(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<JITCUser>()
                .HasOne(user => user.Customer)
                .WithOne(cust => cust.User);

            modelBuilder.Entity<JITCUser>()
                .HasOne(user => user.Pilot)
                .WithOne(pilot => pilot.User);
        }

        private void BuildModificationLogs(ModelBuilder modelBuilder)
        {
            
        }

        private void Seed(ModelBuilder modelBuilder)
        {
            AircraftSeed.Generate(modelBuilder);
            AirportSeed.Generate(modelBuilder);
            FlightSeed.Generate(modelBuilder);
            BookingSeed.Generate(modelBuilder);
        }

        public DbSet<Booking> Bookings { get; set; }

        public DbSet<Aircraft> Aircrafts { get; set; }

        public DbSet<AircraftModel> AircraftModels { get; set; }

        public DbSet<Airport> Airports { get; set; }

        public DbSet<FlightPath> Paths { get; set; }

        public DbSet<Flight> Flights { get; set; }

        public DbSet<FlightReport> FlightReports { get; set; }

        public DbSet<JITCUser> JITCUsers { get; set; }

        public DbSet<Pilot> Pilots { get; set; }

        public DbSet<ModificationLog> Modifications { get; set; }

        public DbSet<Notification> Notifications { get; set; }
    }
}
