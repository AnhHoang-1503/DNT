
namespace DNT.Domain
{
    public class LoginService
    {
        private readonly IJwtProvider _jwtProvider;

        public LoginService(IJwtProvider jwtProvider)
        {
            _jwtProvider = jwtProvider;
        }

        public string Login(User user)
        {
            var token = _jwtProvider.Generate(user);

            return token;
        }
    }
}
