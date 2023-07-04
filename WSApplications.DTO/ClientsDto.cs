namespace WSApplications.DTO
{
    public class ClientsDto
    {
        public Guid ClientId { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Age { get; set; }
        public string IdentificationCard { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool Status { get; set; }
    }
}