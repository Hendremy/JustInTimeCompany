using JustInTimeCompany.Validations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JustInTimeCompany.Models
{
    [ScheduleAttribute(ErrorMessage = "L'heure de décollage doit être avant l'heure d'atterrissage")]

    public class Flight
    {
        public int Id { get; set; }

        [Required]
        public FlightPath Path { get; set; }

        [NotMapped]
        public int FromId { get; set; }

        [NotMapped]
        public int ToId { get; set; }
        public int PilotId { get; set; }

        [Display(Name ="Pilote"), Required]
        public Pilot Pilot { get; set; }


        [NotMapped]
        public int AircraftId { get; set; }

        [Display(Name = "Appareil"), Required]
        public Aircraft Aircraft { get; set; }
        
        public Schedule Schedule { get; set; }

        public FlightReport FlightReport { get; set; }
        
        public IEnumerable<Booking>? Bookings { get; set; }

        [NotMapped]
        [Display(Name ="Places restantes")]
        public int? RemainingSeats => Aircraft != null && Bookings != null ? Aircraft.Capacity - Bookings.Sum(b => b.SeatsTaken) : -1;

        [NotMapped]
        [Display (Name = "Arrivée")]
        public DateTime Landing => Schedule.Landing;

        [NotMapped]
        [Display (Name ="Départ")]
        public DateTime TakeOff => Schedule.TakeOff;

        [NotMapped]
        [Display(Name = "Lieu de départ")]
        public Airport From => Path?.From;

        [NotMapped]
        [Display(Name = "Lieu d'arrivée")]
        public Airport To => Path?.To;

        [NotMapped]
        public AircraftModel? AircraftModel => Aircraft?.Model; 

        [NotMapped]
        public bool HasReport => FlightReport != null;

        [NotMapped]
        public bool IsPassed => Landing < DateTime.Now;

        [NotMapped]
        public bool IsFullyBooked => RemainingSeats == 0;
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
    }
}
