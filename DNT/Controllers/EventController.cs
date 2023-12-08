using DNT.Controllers.Base;
using DNT.Domain;
using DNT.Domain.Service;
using Microsoft.AspNetCore.Mvc;

namespace DNT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : BaseController<Event, EventDto, EventCUDto>
    {
        public EventController(EventService eventService) : base(eventService)
        {
        }
    }
}
