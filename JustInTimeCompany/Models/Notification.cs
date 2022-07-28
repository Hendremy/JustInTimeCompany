namespace JustInTimeCompany.Models
{
    public class Notification
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }

        public string Message { get; set; }

        public DateTime ExpireDate { get; set; }

        public Notification()
        {

        }

        public Notification(int custId, string mess, DateTime expireDate)
        {
            CustomerId = custId;
            Message = mess;
            ExpireDate = expireDate;
        }
    }
}
