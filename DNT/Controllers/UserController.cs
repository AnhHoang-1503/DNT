using DNT.Controllers.Base;
using DNT.Domain;
using Microsoft.AspNetCore.Mvc;

namespace DNT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController<User, UserDto, UserCUDto>
    {
        public UserController(UserService userService) : base(userService)
        {
        }
    }
}
