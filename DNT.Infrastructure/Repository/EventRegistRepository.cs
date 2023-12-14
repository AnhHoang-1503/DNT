using DNT.Domain;

namespace DNT.Infrastructure
{
    public class EventRegistRepository : BaseRepository<EventRegist>, IEventRegistRepository
    {
        public EventRegistRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
