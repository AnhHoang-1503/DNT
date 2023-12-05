
namespace DNT.Domain
{
    public class LoginService
    {
        private readonly IJwtProvider _jwtProvider;
        private readonly UserService _userService;

        public LoginService(IJwtProvider jwtProvider, UserService userService)
        {
            _jwtProvider = jwtProvider;
            _userService = userService;
        }

        public async Task<string> Login(LoginDto loginDto)
        {
            var user = await _userService.FindByUserName(loginDto.UserName);

            if (user == null)
            {
                throw new Exception("user not found");
            }

            if (!BCrypt.Net.BCrypt.Verify(loginDto.Password, user.Password))
            {
                throw new Exception("wrong password");
            }

            var token = _jwtProvider.Generate(user);

            return token;
        }
    }
}
