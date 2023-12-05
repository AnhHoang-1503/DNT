namespace DNT.Domain
{
    public class UserCUDto
    {
        public required string Name { get; set; }

        public required string UserName { get; set; }

        public required string Password { get; set; }

        public required byte Active { get; set; }

        public required string Phone { get; set; }

        public string? Email { get; set; }

        public required string Address { get; set; }

        public required Guid Role_Id { get; set; }

        public required byte Status { get; set; }
    }
}
