namespace WSApplication.DTO
{
    public class TransactionsDto
    {
        public Guid AccountId { get; set; }
        public int TransactionType { get; set; }
        public int Amount { get; set; }
    }
}
