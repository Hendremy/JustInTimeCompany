using Microsoft.EntityFrameworkCore;

namespace JustInTimeCompany.Models
{
    public class SchedNotifier : ISchedNotifier
    {
        public void NotifyChanges(ModificationLog modifLog, JITCDbContext dbContext)
        {
            var before = modifLog.Before;
            var after = modifLog.After;
            var flight = dbContext.Flights
                .Include(fl => fl.Bookings)
                .Include(fl => fl.Path)
                .ThenInclude(p => p.From)
                .Include(fl => fl.Path)
                .ThenInclude(p => p.To)
                .First(fl => fl.Id == 1);

            if(before.Schedule != after.Schedule)
            {
                string message = $"Votre vol de {flight.From.Location} à {flight.To.Location} a été modifié:"
                    + $"\n Ancien planning: {before.Schedule.TakeOff} -> {before.Schedule.Landing}"
                    + $"\n Nouveau planning: {after.Schedule.TakeOff} -> {after.Schedule.Landing}";
                
                foreach (var booking in flight.Bookings)
                {
                    var notif = new Notification(booking.CustomerId, message, after.Schedule.Landing);
                    dbContext.Notifications.Add(notif);
                }
            }
        }
    }

    public interface ISchedNotifier
    {
        public void NotifyChanges(ModificationLog modifLog, JITCDbContext dbContext);
    }
}
