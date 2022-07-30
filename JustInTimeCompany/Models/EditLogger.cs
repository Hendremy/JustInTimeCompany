using Microsoft.EntityFrameworkCore;

namespace JustInTimeCompany.Models
{
    public class EditLogger : IEditLogger 
    {
        public EditLog Log(int flightId, Flight before, Flight after, JITCDbContext dbContext)
        {
            var log = new EditLog(flightId, new FlightArchive(before), new FlightArchive(after));
            dbContext.Add(log);
            dbContext.SaveChanges();
            return log;
        }
    }

    public interface IEditLogger
    {
        public EditLog Log(int flightId, Flight before, Flight after, JITCDbContext context);
    }
}
