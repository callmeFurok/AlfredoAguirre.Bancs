namespace AA.Bancs.Domain.Entity
{
    public class Clients : Persons
    {
        public Guid ClientId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Status { get; set; }

    }
}
