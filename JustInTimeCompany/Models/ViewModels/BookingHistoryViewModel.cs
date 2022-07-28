namespace JustInTimeCompany.Models.ViewModels
{
    public class BookingHistoryViewModel
    {
        public IEnumerable<Notification> Notifications { get; set; }
        public IEnumerable<Booking> Bookings { get; set; }

        public BookingHistoryViewModel(IEnumerable<Notification> notif, IEnumerable<Booking> bookings)
        {
            Notifications = notif;
            Bookings = bookings;
        }
    }
}
