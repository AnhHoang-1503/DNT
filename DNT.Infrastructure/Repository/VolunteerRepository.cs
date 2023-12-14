using DNT.Domain;

namespace DNT.Infrastructure
{
    public class VolunteerRepository : BaseRepository<Volunteer>, IVolunteerRepository
    {
        public VolunteerRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
