using DNT.Domain;

namespace DNT.Infrastructure
{
    public class EventLikeRepository : BaseRepository<EventLike>, IEventLikeRepository
    {
        public EventLikeRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
