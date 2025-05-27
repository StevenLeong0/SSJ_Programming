namespace SeniorLearn.Models
{
    public class ServiceItemHistory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public ICollection<PaymentRecord> PaymentRecords { get; set; } = new List<PaymentRecord>();
    }
}
