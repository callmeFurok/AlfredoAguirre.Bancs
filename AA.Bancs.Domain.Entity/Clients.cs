using System.ComponentModel.DataAnnotations;

namespace WSDomain.Entity
{
    public class Clients : Persons
    {
        [Key]
        public Guid ClientId { get; set; } = Guid.NewGuid();

        public string UserName { get; set; }
        public string Password { get; set; }
        public bool Status { get; set; } = true;
    }
}