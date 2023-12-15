namespace DNT.Domain
{
    public class UserCUDto
    {
        public required string Name { get; set; }

        public required string UserName { get; set; }

        public required string Password { get; set; }

        public required string Phone { get; set; }

        public string? Email { get; set; }

        public required string Address { get; set; }

        public string? Image { get; set; }

    }
}
