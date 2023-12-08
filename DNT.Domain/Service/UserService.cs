using AutoMapper;

namespace DNT.Domain
{
    public class UserService : BaseService<User, UserDto, UserCUDto>
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository, IMapper mapper) : base(userRepository, mapper)
        {
            _userRepository = userRepository;
        }

        public async Task<User?> FindByUserName(string userName)
        {
            var user = await _userRepository.FindByUserName(userName);

            return user;
        }

        public override User MapCUDtoToEntity(UserCUDto userCUDto)
        {
            var user = _mapper.Map<User>(userCUDto);

            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);

            user.Id = Guid.NewGuid();

            return user;
        }

        public override User MapCUDtoToEntity(UserCUDto userCUDto, Guid id)
        {
            var user = _mapper.Map<User>(userCUDto);

            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);

            user.Id = id;

            return user;
        }
    }
}
