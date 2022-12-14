using JustInTimeCompany.Validations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JustInTimeCompany.Models
{
    [PathFromToDifferent(ErrorMessage = "L'aéroport de départ et d'arrivée doivent être différents")]

    public class Flight
    {
        public int Id { get; set; }

        public FlightPath? Path { get; set; }

        [NotMapped]
        [Required]
        public int FromId { get; set; }

        [NotMapped]
        [Required]
        public int ToId { get; set; }
        
        [Required]
        public int PilotId { get; set; }

        [Display(Name ="Pilote")]
        public Pilot? Pilot { get; set; }

        [Required]
        public int AircraftId { get; set; }

        [Display(Name = "Appareil")]
        public Aircraft? Aircraft { get; set; }
        
        [Required]
        [FutureSchedule(ErrorMessage ="L'horaire ne peut être dans le passé")]
        [CoherentSchedule(ErrorMessage = "L'heure de décollage doit être avant l'heure d'atterrissage")]
        public Schedule Schedule { get; set; }

        public FlightReport? FlightReport { get; set; }
        
        public IEnumerable<Booking>? Bookings { get; set; }

        [NotMapped]
        [Display (Name = "Arrivée")]
        public DateTime Landing => Schedule.Landing;

        [NotMapped]
        [Display (Name ="Départ")]
        public DateTime TakeOff => Schedule.TakeOff;

        [NotMapped]
        [Display(Name = "Lieu de départ")]
        public Airport? From => Path?.From;

        [NotMapped]
        [Display(Name = "Lieu d'arrivée")]
        public Airport? To => Path?.To;

        [NotMapped]
        public AircraftModel? AircraftModel => Aircraft?.Model; 

        
        public Flight()
        {
        }

        public Flight(FlightPath path, Schedule sched, Pilot pilot, Aircraft aircraft)
        {
            Path = path;
            Schedule = sched;
            Pilot = pilot;
            Aircraft = aircraft;
        }

        public bool HasReport() => FlightReport != null;
        public bool IsPassed() => TakeOff < DateTime.Now;
        public bool IsFullyBooked() => GetRemainingSeats() == 0;

        public int? GetRemainingSeats() => Aircraft.Capacity - Bookings.Sum(b => b.SeatsTaken);
    }
}
