using System.ComponentModel.DataAnnotations;

namespace AA.Bancs.Domain.Entity
{
    public class Transactions
    {
        [Key]
        public Guid TransactionId { get; set; } = Guid.NewGuid();

        public string Date { get; set; } = DateTime.Now.ToString("dd/MM/yyyy");
        public string TransactionType { get; set; }
        public string Amount { get; set; }
        public string Balance { get; set; }
    }
}