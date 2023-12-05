namespace DNT.Domain
{
    public class UserDto
    {
        public required Guid Id { get; set; }

        public required string Name { get; set; }

        public required string UserName { get; set; }

        public required byte Active { get; set; }

        public required string Phone { get; set; }

        public string? Email { get; set; }

        public required string Address { get; set; }

        public required Guid Role_Id { get; set; }

        public required byte Status { get; set; }
    }
}
