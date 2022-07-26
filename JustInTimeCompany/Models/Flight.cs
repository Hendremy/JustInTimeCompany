using JustInTimeCompany.Validations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JustInTimeCompany.Models
{
    public class Flight
    {
        public int Id { get; set; }

        public FlightPath Path { get; set; }

        public int PilotId { get; set; }

        public Pilot Pilot { get; set; }

        public Aircraft? Aircraft { get; set; }

        [ScheduleAttribute(ErrorMessage = "L'heure de décollage doit être avant l'heure d'atterrissage")]
        public Schedule Schedule { get; set; }

        public FlightReport FlightReport { get; set; }
        
        public IEnumerable<Booking>? Bookings { get; set; }

        [NotMapped]
        [Display(Name ="Places restantes")]
        public int RemainingSeats => Aircraft != null && Bookings != null ? Aircraft.Capacity - Bookings.Sum(b => b.SeatsTaken) : -1;

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
        public AircraftModel AircraftModel => Aircraft.Model; 

        [NotMapped]
        public bool HasReport => FlightReport != null;

        [NotMapped]
        public bool IsPassed => Landing < DateTime.Now;

        [NotMapped]
        public bool IsFullyBooked => RemainingSeats == 0;
        public Flight()
        {
            Schedule = new Schedule(DateTime.Now, DateTime.Now.AddHours(1));
        }
    }
}
