using JustInTimeCompany.Validations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JustInTimeCompany.Models
{
    //[Delay(ErrorMessage="Veuillez renseigner la raison du retard de votre vol")]
    public class FlightReport
    {
        private static int MAX_DELAY = 5;

        public int Id { get; set; }
        [Required]
        public int FlightId { get; set; }
        public Flight? Flight { get; set; }
        [Required]
        public Schedule ActualSchedule { get; set; }

        [NotMapped]
        [Display(Name="Heure de décollage définitive")]
        public DateTime TakeOff => ActualSchedule.TakeOff;

        [NotMapped]
        [Display(Name = "Heure d'atterrissage définitive")]

        public DateTime Landing => ActualSchedule.Landing;

        [NotMapped]
        public double Delay => Flight != null ? (ActualSchedule.Landing - Flight.Landing).TotalMinutes : -1;

        [NotMapped]
        public bool HasDelay => Delay > MAX_DELAY;
        
        [Display(Name="Raison du retard")]
        public string? DelayJustification { get; set; }

        public FlightReport()
        {

        }

        public FlightReport(Flight flight)
        {
            ActualSchedule = new Schedule(flight.TakeOff, flight.Landing);
            Flight = flight;
            FlightId = flight.Id;
            DelayJustification = " ";
        }
    }
}
