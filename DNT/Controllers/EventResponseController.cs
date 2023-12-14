using DNT.Controllers.Base;
using DNT.Domain;
using Microsoft.AspNetCore.Mvc;

namespace DNT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventResponseController : BaseController<EventResponse, EventResponseDto, EventResponseCUDto>
    {
        public EventResponseController(EventResponseService eventResponseService) : base(eventResponseService)
        {
        }
    }
}
