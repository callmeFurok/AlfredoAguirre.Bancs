using System.ComponentModel.DataAnnotations;

namespace WSDomain.Entity
{
    public class Transactions
    {
        [Key]
        public Guid TransactionId { get; set; } = Guid.NewGuid();
        public Guid AccountId { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;
        public string TransactionType { get; set; }
        public string Amount { get; set; }
        public string Balance { get; set; }
    }
}