namespace AA.Bancs.Domain.Entity
{
    public class Accounts
    {
        public Guid AccountId { get; set; }
        public string AccountNumber { get; set; }
        public string AccountType { get; set; }
        public string InitialBalance { get; set; }
        public string Status { get; set; }
    }
}
