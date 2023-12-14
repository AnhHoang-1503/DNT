using AutoMapper;
using DNT.Domain.Common;

namespace DNT.Domain
{
    public class UserService : BaseService<User, UserDto, UserCUDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly UserSessionState _userSessionState;

        public UserService(IUserRepository userRepository, UserSessionState userSessionState, IMapper mapper) : base(userRepository, mapper)
        {
            _userRepository = userRepository;
            _userSessionState = userSessionState;
        }

        public async Task<User?> FindByUserName(string userName)
        {
            var user = await _userRepository.FindByUserName(userName);

            return user;
        }

        public async Task<UserDto?> GetCurrentUser()
        {
            if (!_userSessionState.Id.HasValue)
            {
                throw new Exception("User is not logged in");
            }

            var user = await _userRepository.FindById(_userSessionState.Id.Value);

            var userDto = _mapper.Map<UserDto>(user);

            return userDto;
        }

        public override User MapCUDtoToEntity(UserCUDto userCUDto)
        {
            var user = _mapper.Map<User>(userCUDto);

            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);

            user.Id = Guid.NewGuid();

            user.Active = true;

            user.Role = Role.User;

            user.Status = Status.initial;

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
