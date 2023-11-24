
namespace DNT.Domain
{
    public class User : IHasKey
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public required string Account { get; set; }

        public required string Password { get; set; }

        public Guid GetKey()
        {
            return Id;
        }
    }
}
