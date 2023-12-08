using AutoMapper;

namespace DNT.Domain.Service
{
    public class EventService : BaseService<Event, EventDto, EventCUDto>
    {
        public EventService(IEventRepository eventRepository, IMapper mapper) : base(eventRepository, mapper)
        {
        }

        public override Event MapCUDtoToEntity(EventCUDto entityCUDto)
        {
            var eventEntity = _mapper.Map<Event>(entityCUDto);

            eventEntity.Id = Guid.NewGuid();

            eventEntity.Created_Date = DateTime.Now;

            eventEntity.Modified_Date = DateTime.Now;

            return eventEntity;
        }

        public override Event MapCUDtoToEntity(EventCUDto entityCUDto, Guid id)
        {
            var eventEntity = _mapper.Map<Event>(entityCUDto);

            eventEntity.Id = id;

            eventEntity.Modified_Date = DateTime.Now;

            return eventEntity;
        }
    }
}
