using DNT.Domain;

namespace DNT.Infrastructure
{
    public class CharityOrganizationRepository : BaseRepository<CharityOrganization>, ICharityOrganizationRepository
    {
        public CharityOrganizationRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
