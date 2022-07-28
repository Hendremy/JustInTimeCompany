using Microsoft.EntityFrameworkCore;

namespace JustInTimeCompany.Models
{
    public class ModificationLogger : IModificationLogger 
    {
        public ModificationLog Log(Flight before, Flight after, JITCDbContext dbContext)
        {
            var log = new ModificationLog(new FlightArchive(before), new FlightArchive(after));

            dbContext.Modifications.Add(log);
            return log;
        }
    }

    public interface IModificationLogger
    {
        public ModificationLog Log(Flight before, Flight after, JITCDbContext context);
    }
}
