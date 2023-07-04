using System.ComponentModel.DataAnnotations;

namespace WSDomain.Entity
{
    public class Transactions
    {
        [Key]
        public Guid TransactionId { get; set; } = Guid.NewGuid();
        public Guid AccountId { get; set; }
        public int InitialBalance { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;
        public int TransactionType { get; set; }
        public int Amount { get; set; }
        public int Balance { get; set; }
    }
}