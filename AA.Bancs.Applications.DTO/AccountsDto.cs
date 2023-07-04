namespace WSApplication.DTO
{
    public class AccountsDto
    {
        public Guid ClientId { get; set; }

        public string AccountNumber { get; set; }
        public string AccountType { get; set; }
        public string InitialBalance { get; set; }
        public bool Status { get; set; } = true;
    }
}
