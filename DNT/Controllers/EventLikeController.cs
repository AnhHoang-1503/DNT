using DNT.Controllers.Base;
using DNT.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DNT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventLikeController : BaseController<EventLike, EventLikeDto, EventLikeCUDto>
    {
        public EventLikeController(EventLikeService eventLikeService) : base(eventLikeService)
        {
        }
    }
}
