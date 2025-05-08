namespace SeniorLearn.Models
{
    public class PaymentMethod
    {
        public int Id { get; set; }
        public string Name { get; set; } // Cash, EFT, CreditCard, Cheque, BankTransfer

        public ICollection<PaymentRecord> PaymentRecords { get; set; } = new List<PaymentRecord>();
    }
}
