using JustInTimeCompany.Models.Seed;
using Microsoft.EntityFrameworkCore;

namespace JustInTimeCompany.Models
{
    public class JITCDbContext : DbContext
    {
        public JITCDbContext(DbContextOptions<JITCDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Booking>().HasKey(b => new { b.FlightId, b.CustomerId });

            modelBuilder.Entity<FlightReport>().HasOne(fr => fr.FlightInstance)
                .WithOne(fi => fi.FlightReport)
                .HasForeignKey<FlightReport>(fr => fr.FlightInstanceId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<FlightInstance>().HasOne(fi => fi.Aircraft).WithMany(fr => fr.FlightInstances);

            modelBuilder.Entity<FlightInstance>().HasOne(fi => fi.Pilot).WithMany(p => p.FlightInstances);

            modelBuilder.Entity<Customer>().HasMany(c => c.Bookings).WithOne(b => b.Customer);

            modelBuilder.Entity<Flight>().HasKey(f => new { f.FromId, f.ToId });

            modelBuilder.Entity<Flight>().HasOne(f => f.From)
                .WithMany(a => a.OutgoingFlights)
                .HasForeignKey(f => f.FromId)
                .OnDelete(DeleteBehavior.NoAction);
            
            modelBuilder.Entity<Flight>().HasOne(f => f.To)
                .WithMany(a => a.IncomingFlights)
                .HasForeignKey(f => f.ToId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<EngineInAircraft>().HasKey(eia => new { eia.EngineId, eia.ModelId });

            Seed(modelBuilder);
        }

        private void Seed(ModelBuilder modelBuilder)
        {
            AircraftSeed.Generate(modelBuilder);
            AirportSeed.Generate(modelBuilder);
        }

        public DbSet<Booking> Bookings { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Aircraft> Aircrafts { get; set; }

        public DbSet<AircraftModel> AircraftModels { get; set; }

        public DbSet<Airport> Airports { get; set; }

        public DbSet<Pilot> Pilots { get; set; }

        public DbSet<Flight> Flights { get; set; }
    }
}
