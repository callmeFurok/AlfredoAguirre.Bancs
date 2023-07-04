namespace WSDomain.Entity
{
    public class Persons
    {
        public Guid PersonId { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Age { get; set; }
        public string IdentificationCard { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }
    }
}