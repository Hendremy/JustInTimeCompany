namespace JustInTimeCompany.Models
{
    public class FlightRepeater : IFlightRepeater
    {
        private const int MAX_MONTHS = 6;
        private const int WEEKDAYS = 7;
        private const int MONTHSDAYS = 31;

        public IEnumerable<Flight> RepeatFlight(Flight flight, Frequency frequency) {
            return frequency switch
            {
                Frequency.Once => RepeatOnce(flight),
                Frequency.Daily => RepeatDaily(flight),
                Frequency.Weekly => RepeatWeekly(flight),
                Frequency.Monthly => RepeatMonthly(flight),
                _ => new List<Flight>() { flight}
            };
        }

        private IEnumerable<Flight> RepeatOnce(Flight flight)
        {
            return new List<Flight>() { flight };
        }

        private IEnumerable<Flight> RepeatDaily(Flight flight)
        {
            var repeatList = new List<Flight>();
            for(int d = 0; d < WEEKDAYS * MAX_MONTHS; d++)
            {
                var newSched = new Schedule(flight.TakeOff, flight.Landing);
                newSched.AddDays(d);
                repeatList.Add(new Flight(flight.Path, newSched, flight.Pilot, flight.Aircraft));
            }
            return repeatList;
        }

        private IEnumerable<Flight> RepeatWeekly(Flight flight)
        {
            var repeatList = new List<Flight>();
            for (int d = 0; d < MONTHSDAYS * MAX_MONTHS; d += WEEKDAYS)
            {
                var newSched = new Schedule(flight.TakeOff, flight.Landing);
                newSched.AddDays(d);
                repeatList.Add(new Flight(flight.Path, newSched, flight.Pilot, flight.Aircraft));
            }
            return repeatList;
        }

        private IEnumerable<Flight> RepeatMonthly(Flight flight)
        {
            var repeatList = new List<Flight>();
            for (int m = 0; m < MAX_MONTHS; m++)
            {
                var newSched = new Schedule(flight.TakeOff, flight.Landing);
                newSched.AddMonths(m);
                repeatList.Add(new Flight(flight.Path, newSched, flight.Pilot, flight.Aircraft));
            }
            return repeatList;
        }

    }

    public interface IFlightRepeater
    {
        public IEnumerable<Flight> RepeatFlight(Flight flight, Frequency frequency);
    }
}
