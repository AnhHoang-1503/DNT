namespace DNT.Domain
{
    public class UserService : BaseService<User>
    {
        public UserService(IUserRepository userRepository) : base(userRepository)
        {
        }
    }
}
