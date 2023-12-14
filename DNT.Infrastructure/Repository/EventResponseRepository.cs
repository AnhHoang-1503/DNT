using DNT.Domain;

namespace DNT.Infrastructure
{
    public class EventResponseRepository : BaseRepository<EventResponse>, IEventResponseRepository
    {
        public EventResponseRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
