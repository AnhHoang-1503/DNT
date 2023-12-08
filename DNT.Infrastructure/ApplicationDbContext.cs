using DNT.Domain;
using Microsoft.EntityFrameworkCore;

namespace DNT.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User> User { get; set; }

        public DbSet<ForHelpRequest> ForHelpRequest { get; set; }

        public DbSet<Event> Event { get; set; }

    }
}
