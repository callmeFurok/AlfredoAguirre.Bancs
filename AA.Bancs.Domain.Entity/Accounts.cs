using System.ComponentModel.DataAnnotations;

namespace WSDomain.Entity
{
    public class Accounts
    {
        [Key]
        public Guid AccountId { get; set; } = Guid.NewGuid();
        public Guid ClientId { get; set; }

        public string AccountNumber { get; set; }
        public string AccountType { get; set; }
        public string InitialBalance { get; set; }
        public bool Status { get; set; } = true;
    }
}