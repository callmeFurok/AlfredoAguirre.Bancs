using System.ComponentModel.DataAnnotations;

namespace AA.Bancs.Domain.Entity
{
    public class Accounts
    {
        [Key]
        public Guid AccountId { get; set; } = Guid.NewGuid();

        public string AccountNumber { get; set; }
        public string AccountType { get; set; }
        public string InitialBalance { get; set; }
        public bool Status { get; set; } = true;
    }
}