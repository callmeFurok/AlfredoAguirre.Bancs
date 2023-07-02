namespace AA.Bancs.Domain.Entity
{
    public class Transactions
    {
        public Guid TransactionId { get; set; }
        public string Date { get; set; }
        public string TransactionType { get; set; }
        public string Amount { get; set; }
        public string Balance { get; set; }
    }
}
