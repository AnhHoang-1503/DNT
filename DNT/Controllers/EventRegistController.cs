using DNT.Controllers.Base;
using DNT.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DNT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventRegistController : BaseController<EventRegist, EventRegistDto, EventRegistCUDto>
    {
        public EventRegistController(EventRegistService eventRegistService) : base(eventRegistService)
        {
        }
    }
}
