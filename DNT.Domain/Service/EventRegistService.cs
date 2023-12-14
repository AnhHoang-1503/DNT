
using AutoMapper;

namespace DNT.Domain
{
    public class EventRegistService : BaseService<EventRegist, EventRegistDto, EventRegistCUDto>
    {
        public EventRegistService(IEventRegistRepository eventRegistRepository, IMapper mapper) : base(eventRegistRepository, mapper)
        {
        }

        public override EventRegist MapCUDtoToEntity(EventRegistCUDto entityCUDto)
        {
            var eventRegist = _mapper.Map<EventRegist>(entityCUDto);

            eventRegist.Id = Guid.NewGuid();

            return eventRegist;
        }

        public override EventRegist MapCUDtoToEntity(EventRegistCUDto entityCUDto, Guid id)
        {
            var eventRegist = _mapper.Map<EventRegist>(entityCUDto);

            eventRegist.Id = id;

            return eventRegist;
        }
    }
}
