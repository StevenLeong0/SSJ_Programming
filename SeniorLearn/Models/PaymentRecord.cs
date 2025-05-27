namespace SeniorLearn.Models
{
    public class PaymentRecord
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public int ServiceItemHistoryId { get; set; }
        public int PaymentMethodId { get; set; }
        public string Notes { get; set; }
        public DateTime DatePaid { get; set; }

        public Member Member { get; set; }
        public ServiceItemHistory ServiceItemHistory { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
    }
}
