namespace DNT.Domain
{
    public class CharityOrganizationCUDto
    {
        public DateTime Establish_Date { get; set; }

        public string? Fax { get; set; }

        public string? Website { get; set; }

        public string? Description { get; set; }

        public Guid Volunteer_Id { get; set; }
    }
}
