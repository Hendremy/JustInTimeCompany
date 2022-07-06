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
                .HasForeignKey<FlightReport>(fr => fr.FlightInstanceId);

            Seed(modelBuilder);
        }

        private void Seed(ModelBuilder modelBuilder)
        {

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
