﻿
namespace DNT.Domain
{
    public class User : IHasKey
    {
        public required Guid Id { get; set; }

        public required string Name { get; set; }

        public required string UserName { get; set; }

        public required string Password { get; set; }

        public required Boolean Active { get; set; }

        public required string Phone { get; set; }

        public string? Email { get; set; }

        public required string Address { get; set; }

        public required Role Role { get; set; }

        public required Status Status { get; set; }

        public Guid GetKey()
        {
            return Id;
        }
    }
}
