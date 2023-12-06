using DNT.Domain;

namespace DNT.Infrastructure.Repository
{
    public class ForHelpRequestRepository : BaseRepository<ForHelpRequest>, IForHelpRequestRepository
    {
        public ForHelpRequestRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
